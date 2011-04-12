﻿using System;
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

namespace PlexMediaClient.Util {
    public static class Transcoding {

        public static event OnMediaReadyEventHandler OnMediaReady;
        public delegate void OnMediaReadyEventHandler(List<string> mediaFileName);
        private static AutoResetEvent _cancelationDoneEvent = new AutoResetEvent(false);


        private static BackgroundWorker _mediaBufferer;
        private static WebClient _mediaFetcher;
        private static int Quality { get; set; }
        private static int Buffer { get; set; }
        private const string _bufferFile = @"D:\buffer.ts";
        private const int _defaultBuffer = 3;
        private const int _defaultQuality = 5;
        private static FileStream _bufferedMedia;

        static Transcoding() {
            if (File.Exists(_bufferFile)) {
                File.Delete(_bufferFile);
            }
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
            if (File.Exists(_bufferFile)) {
                File.Delete(_bufferFile);
            }
            _bufferedMedia = new FileStream(_bufferFile, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
            PlexInterface.PlexServerCurrent.AddAuthHeaders(ref _mediaFetcher);
        }
        
        static void MediaBufferer_DoWork(object sender, DoWorkEventArgs e) {
            ResetMediaBuffer();
            if (e.Argument is MediaContainerVideo) {                
                int bufferedSegments = 0;
                foreach (string currentPart in PlexInterface.GetAllVideoParts((MediaContainerVideo)e.Argument)) {                    
                    foreach (string segment in GetM3U8PlaylistItems(PlexInterface.PlexServerCurrent, currentPart)) {
                        if (_mediaBufferer.CancellationPending) {
                            e.Cancel = true;
                            return;
                        }
                        byte[] data = _mediaFetcher.DownloadData(segment);
                        _bufferedMedia.Write(data, 0, data.Length);
                        _bufferedMedia.Flush();
                        _mediaBufferer.ReportProgress((int)_bufferedMedia.Length);
                        if (++bufferedSegments == Buffer) {
                            OnMediaReady(new List<string>{_bufferFile});
                        }
                    }       
                }
                _mediaFetcher.Dispose();
                _bufferedMedia.Close();
            }
        }

        static void MediaBufferer_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            Console.WriteLine(e.ProgressPercentage);
        } 
        
        static void _mediaBufferer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            _cancelationDoneEvent.Set();
        }      

        private static void BufferMediaAsync(MediaContainerVideo mediaContainerVideo) {
            
            if (!_mediaBufferer.IsBusy) {
                _mediaBufferer.RunWorkerAsync(mediaContainerVideo);
            }
        }

        internal static void BufferMedia(MediaContainerVideo mediaContainerVideo) {            
            BufferMedia(mediaContainerVideo, _defaultQuality, _defaultQuality);
        }

        internal static void BufferMedia(MediaContainerVideo mediaContainerVideo, int quality, int buffer) {
            Quality = quality;
            Buffer = buffer;
            BufferMediaAsync(mediaContainerVideo);
        }

        internal static void StopBuffering() {
            if (_mediaBufferer.IsBusy) {
                _mediaBufferer.CancelAsync();
                _cancelationDoneEvent.WaitOne();
            }
        }

        internal static void PlayBackMedia(MediaContainerVideo mediaContainerVideo) {
            StopBuffering();
            if (PlexInterface.IsLANConnected){
                PlayBackLive(mediaContainerVideo);                
            } else {
                PlayBackTranscoded(mediaContainerVideo);
            }
        }

        private static void PlayBackTranscoded(MediaContainerVideo mediaContainerVideo) {
            PlexServerCapabilities currentCaps = PlexInterface.PlexServerCurrent.ServerCapabilities;
            BufferMedia(mediaContainerVideo);
            if (PlexInterface.Is3GConnected) {

            } else { 
                
            }
        }

        private static void PlayBackLive(MediaContainerVideo mediaContainerVideo) {
            OnMediaReady(PlexInterface.GetAllVideoParts(mediaContainerVideo).ToList().ConvertAll(part => PlexInterface.PlexServerCurrent.UriPlexBase + part));
        }


        


        public static IEnumerable<string> GetM3U8PlaylistItems(PlexServer plexServer, string partKey) {
            // unix time is the number of milliseconds from 1/1/1970 to now..          
            DateTime jan1 = new DateTime(1970, 1, 1, 0, 0, 0);

            double dTime = (DateTime.Now - jan1).TotalMilliseconds;

            // as per the Javascript example, round up the Unix time
            string time = Math.Round(dTime / 1000).ToString();

            // the basic url WITH the part key is:
            string url = "/video/:/transcode/segmented/start.m3u8?identifier=com.plexapp.plugins.library&offset=0&quality=12&url=http%3A%2F%2Flocalhost%3A32400" + Uri.EscapeDataString(partKey) + "&3g=0";
            // the message to hash is url + an @ + the rounded time
            string msg = url + "@" + time;
            string publicKey = "KQMIY6GATPC63AIMC4R2";
            byte[] privateKey = Convert.FromBase64String("k3U6GLkZOoNIoSgjDshPErvqMIFdE0xMTx8kgsrhnC0=");

            // initialize a new HMACSHA256 class with the private key from Elan
            HMACSHA256 hmac = new HMACSHA256(privateKey);

            // compute the hash of the message. Note: .net is unicode double byte, so when we get the bytes
            // from the message we have to be sure to use UTF8 decoders.

            hmac.ComputeHash(UTF8Encoding.UTF8.GetBytes(msg));

            //our new super secret token is our new hash converted to a Base64 string
            string token = Convert.ToBase64String(hmac.Hash);

            // now that we have our information, it's time to make the HTTP request.
            // Step 1: create a new web client
            WebClient wc = new WebClient();
            plexServer.AddAuthHeaders(ref wc);
            // Step 2: add the magic headers with the values we just computed.
            wc.Headers.Add("X-Plex-Access-Key", publicKey);
            wc.Headers.Add("X-Plex-Access-Time", time);
            wc.Headers.Add("X-Plex-Access-Code", token);
            wc.Headers.Add("X-Plex-Client-Capabilities", PlexClientCapabilities.GetClientCapabilities());

            string response = wc.DownloadString(new Uri(plexServer.UriPlexBase, url));
            string session = response.Substring(response.IndexOf("session")).Replace("\n", "");

            string playListRequest = plexServer.UriPlexBase.AbsoluteUri + "video/:/transcode/segmented/" + session;

            string cookie = wc.ResponseHeaders[HttpResponseHeader.SetCookie];



            if (cookie != null && cookie.Length > 0)
                wc.Headers[HttpRequestHeader.Cookie] = cookie;
            string playList = wc.DownloadString(playListRequest);
            List<string> playListItems = playList.Split(new char[] { '\n' }).Where(item => item.EndsWith(".ts")).ToList();
            foreach (string currentItem in playListItems) {
                yield return playListRequest.Replace("index.m3u8", currentItem);
            }
        }

        public static string GetM3U8PlaylistUrl(PlexServer plexServer, string partKey) {
            // unix time is the number of milliseconds from 1/1/1970 to now..          
            DateTime jan1 = new DateTime(1970, 1, 1, 0, 0, 0);

            double dTime = (DateTime.Now - jan1).TotalMilliseconds;

            // as per the Javascript example, round up the Unix time
            string time = Math.Round(dTime / 1000).ToString();

            // the basic url WITH the part key is:
            string url = "/video/:/transcode/segmented/start.m3u8?identifier=com.plexapp.plugins.library&offset=0&quality=5&url=http%3A%2F%2Flocalhost%3A32400" + Uri.EscapeDataString(partKey) + "&3g=0&httpCookies=&userAgent=";
            // the message to hash is url + an @ + the rounded time
            string msg = url + "@" + time;
            string publicKey = "KQMIY6GATPC63AIMC4R2";
            byte[] privateKey = Convert.FromBase64String("k3U6GLkZOoNIoSgjDshPErvqMIFdE0xMTx8kgsrhnC0=");

            // initialize a new HMACSHA256 class with the private key from Elan
            HMACSHA256 hmac = new HMACSHA256(privateKey);

            // compute the hash of the message. Note: .net is unicode double byte, so when we get the bytes
            // from the message we have to be sure to use UTF8 decoders.

            hmac.ComputeHash(UTF8Encoding.UTF8.GetBytes(msg));

            //our new super secret token is our new hash converted to a Base64 string
            string token = Convert.ToBase64String(hmac.Hash);

            // now that we have our information, it's time to make the HTTP request.
            // Step 1: create a new web client
            WebClient wc = new WebClient();
            plexServer.AddAuthHeaders(ref wc);
            // Step 2: add the magic headers with the values we just computed.
            wc.Headers.Add("X-Plex-Access-Key", publicKey);
            wc.Headers.Add("X-Plex-Access-Time", time);
            wc.Headers.Add("X-Plex-Access-Code", token);
            wc.Headers.Add("X-Plex-Client-Capabilities", PlexClientCapabilities.GetClientCapabilities());

            string response = wc.DownloadString(new Uri(plexServer.UriPlexBase, url));
            string session = response.Substring(response.IndexOf("session")).Replace("\n", "");

            return plexServer.UriPlexBase.AbsoluteUri + "video/:/transcode/segmented/" + session;
        }
    }
}