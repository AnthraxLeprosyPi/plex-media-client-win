using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlexMediaClient.Plex;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using System.ComponentModel;
using System.Threading;
using PlexMediaClient.Plex.Xml;
using WMPLib;

namespace PlexMediaClient.Util {
    public static class Transcoding {

        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static event OnPlayBufferedMediaEventHandler OnPlayBufferedMedia;
        public delegate void OnPlayBufferedMediaEventHandler(string localBufferPath);
        public static event OnPlayHttpAdaptiveStreamEventHandler OnPlayHttpAdaptiveStream;
        public delegate void OnPlayHttpAdaptiveStreamEventHandler(Uri m3u8Url);
        private static ManualResetEventSlim _safeCompletionEvent = new ManualResetEventSlim(false);

        private const string _plexApiPublicKey = "KQMIY6GATPC63AIMC4R2";
        private const string _plexApiSharedSecret = "k3U6GLkZOoNIoSgjDshPErvqMIFdE0xMTx8kgsrhnC0=";

        private static BackgroundWorker _mediaBufferer;
        private static WebClient _mediaFetcher;
        private static int Quality { get; set; }
        private static int Buffer { get; set; }
        private const string _bufferFile = @"D:\buffer.ts";
        private const int _defaultBuffer = 2;
        private const int _defaultQuality = 5;
        private static FileStream _bufferedMedia;

        static Transcoding() {
            logger.Info(" started...");
            ResetMediaBuffer();
            Buffer = _defaultBuffer;
            Quality = _defaultQuality;
            _mediaFetcher = new WebClient();
            _mediaBufferer = new BackgroundWorker();
            _mediaBufferer.WorkerSupportsCancellation = true;
            _mediaBufferer.WorkerReportsProgress = true;
            _mediaBufferer.ProgressChanged += new ProgressChangedEventHandler(MediaBufferer_ProgressChanged);
            _mediaBufferer.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_mediaBufferer_RunWorkerCompleted);
            _mediaBufferer.DoWork += new DoWorkEventHandler(MediaBufferer_DoWork);
            
        }

        private static void ResetMediaBuffer() {
            try {
                if (_bufferedMedia != null) {
                    _bufferedMedia.Dispose();
                }
                if (File.Exists(_bufferFile)) {
                    File.Delete(_bufferFile);
                }
                _bufferedMedia = new FileStream(_bufferFile, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
            } catch (Exception e) {
                logger.FatalException("Unable reset local media buffer!", e);
            }

        }

        static void MediaBufferer_DoWork(object sender, DoWorkEventArgs e) {
            logger.Info("BackGroundWorker - Buffering...");
            _safeCompletionEvent.Reset();
            if (e.Argument is IEnumerable<string>) {
                int bufferedSegments = 0;
                foreach (string segment in (IEnumerable<string>)e.Argument) {
                    if (_mediaBufferer.CancellationPending) {
                        logger.Info("BackGroundWorker - CancellationPending detected - cancelling asynchronous buffering...");
                        e.Cancel = true;
                        return;
                    }
                    byte[] data = _mediaFetcher.DownloadData(segment);
                    _bufferedMedia.Write(data, 0, data.Length);
                    _bufferedMedia.Flush();
                    _mediaBufferer.ReportProgress((int)_bufferedMedia.Length);
                    if (++bufferedSegments == Buffer) {
                        OnPlayBufferedMedia();
                    }
                }
            }
        }

        static void MediaBufferer_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            Console.WriteLine(e.ProgressPercentage);
        }

        static void _mediaBufferer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                logger.Warn("BackGroundWorker -Buffering completed and was cancelled");
            } else if (e.Error != null) {
                logger.ErrorException("BackGroundWorker -Buffering completed with Exception", e.Error);
            } else {
                logger.Info("BackGroundWorker -Buffering completed and was successful");
            }
            _safeCompletionEvent.Set();
        }

        private static void BufferMediaAsync(IEnumerable<string> segmentedParts) {
            StopBuffering();
            _mediaBufferer.RunWorkerAsync(segmentedParts);
        }

        internal static void StopBuffering() {
            logger.Info("Request Buffering Cancellation");
            if (_mediaBufferer.IsBusy) {
                _mediaBufferer.CancelAsync();
                _safeCompletionEvent.Wait(20000);
            }
            ResetMediaBuffer();
        }

        private static List<string> InternalPlayList { get; set; }

        internal static void PlayBackMedia(MediaContainerVideo video) {
            IWMPPlaylist newPlaylist = MediaPlayer.newPlaylist(video.title, "");
            InternalPlayList = new List<string>();
            foreach (string currentPart in PlexInterface.GetAllVideoPartKeys(video)) {
                InternalPlayList.Add(currentPart);
                IWMPMedia currentItem = MediaPlayer.newMedia(_bufferFile);               
                newPlaylist.appendItem(currentItem);
            }
            OnPlayHttpAdaptiveStream(newPlaylist);
        }

        internal static void BufferMedia(int index, int offset = 0) {
            BufferMediaAsync(GetM3U8PlaylistItems(PlexInterface.PlexServerCurrent, InternalPlayList[index]));
        }

        static IEnumerable<string> GetM3U8PlaylistItems(PlexServer plexServer, string partKey) {
            string response = _mediaFetcher.DownloadString(GetM3U8PlaylistUrl(plexServer, partKey));
            string session = response.Substring(response.IndexOf("session")).Replace("\n", "");

            string playListRequest = plexServer.UriPlexBase.AbsoluteUri + "video/:/transcode/segmented/" + session;

            string cookie = _mediaFetcher.ResponseHeaders[HttpResponseHeader.SetCookie];
            if (cookie != null && cookie.Length > 0)
                _mediaFetcher.Headers[HttpRequestHeader.Cookie] = cookie;
            string playList = _mediaFetcher.DownloadString(playListRequest);
            List<string> playListItems = playList.Split(new char[] { '\n' }).Where(item => item.EndsWith(".ts")).ToList();
            foreach (string currentItem in playListItems) {
                yield return playListRequest.Replace("index.m3u8", currentItem);
            }
        }

        static Uri GetM3U8PlaylistUrl(PlexServer plexServer, string partKey, long offset = 0, int quality = _defaultQuality, bool is3G = false) {
            string transcodePath = "/video/:/transcode/segmented/start.m3u8?";
            transcodePath += "identifier=com.plexapp.plugins.library";
            transcodePath += "&offset=" + offset;
            transcodePath += "&qualitiy=" + quality;
            transcodePath += "&3g=" + (is3G ? "1" : "0");
            transcodePath += "&url=" + Uri.EscapeDataString("http://localhost:32400" + partKey);
            transcodePath += GetPlexAuthParameters(plexServer, transcodePath);
            transcodePath += PlexClientCapabilities.GetClientCapabilities();
            transcodePath += "&httpCookies=";
            transcodePath += "&userAgent=";

            return new Uri(plexServer.UriPlexBase + transcodePath.Remove(0, 1));
        }

        private static string GetPlexAuthParameters(PlexServer plexServer, string url) {
            string time = GetUnixTime();
            string authParameters = string.Empty;
            authParameters += "&X-Plex-User=" + plexServer.UserName;
            authParameters += "&X-Plex-Pass=" + plexServer.UserPass;
            authParameters += "&X-Plex-Access-Key=" + _plexApiPublicKey;
            authParameters += "&X-Plex-Access-Time=" + time;
            authParameters += "&X-Plex-Access-Code=" + Uri.EscapeDataString(GetPlexApiToken(url, time));
            return authParameters;
        }

        private static string GetPlexApiToken(string url, string time) {
            // the message to hash is url + an @ + the rounded time   
            string msg = url + "@" + time;
            byte[] privateKey = Convert.FromBase64String(_plexApiSharedSecret);

            // initialize a new HMACSHA256 class with the private key from Elan
            HMACSHA256 hmac = new HMACSHA256(privateKey);

            // compute the hash of the message. Note: .net is unicode double byte, so when we get the bytes
            // from the message we have to be sure to use UTF8 decoders.
            hmac.ComputeHash(UTF8Encoding.UTF8.GetBytes(msg));

            //our new super secret token is our new hash converted to a Base64 string
            return Convert.ToBase64String(hmac.Hash);
        }

        private static string GetUnixTime() {
            // unix time is the number of milliseconds from 1/1/1970 to now..          
            DateTime jan1 = new DateTime(1970, 1, 1, 0, 0, 0);
            double dTime = (DateTime.Now - jan1).TotalMilliseconds;
            // as per the Javascript example, round up the Unix time
            string time = Math.Round(dTime / 1000).ToString();
            // the basic url WITH the part key is:
            return time;
        }



        public static AxWMPLib.AxWindowsMediaPlayer MediaPlayer { get; set; }
    }
}
