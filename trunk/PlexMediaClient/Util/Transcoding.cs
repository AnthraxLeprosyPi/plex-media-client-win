using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlexMediaClient.Plex;
using System.Security.Cryptography;
using System.IO;
using System.Net;

namespace PlexMediaClient.Util {
   public static class Transcoding {

      public static string GetM3U8Playlist(PlexServer plexServer, string partKey) {
           // unix time is the number of milliseconds from 1/1/1970 to now..

           DateTime jan1 = new DateTime(1970, 1, 1, 0, 0, 0);

           double dTime = (DateTime.Now - jan1).TotalMilliseconds;
           
           // as per the Javascript example, round up the Unix time
           string time = Math.Round(dTime / 1000).ToString();

           // the basic url WITH the part key is:
          string url = plexServer.UriPlexBase + "video/:/transcode/segmented/start.m3u8?identifier=com.plexapp.plugins.library&offset=0&quality=5&url=" + Uri.EscapeDataString(new Uri(plexServer.UriPlexBase,partKey).AbsoluteUri) + "&3g=0";

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
           System.Net.WebClient wc = new System.Net.WebClient();
           plexServer.AddAuthHeaders(ref wc);
           // Step 2: add the magic headers with the values we just computed.
           wc.Headers.Add("X-Plex-Access-Key", publicKey);
           wc.Headers.Add("X-Plex-Access-Time", time);
           wc.Headers.Add("X-Plex-Access-Code", token);
           string m3u8Content = wc.DownloadString(url);

           string s = wc.DownloadString(plexServer.UriPlexBase + url);

           s = s.Substring(s.IndexOf("session")).Replace("\n", "");

           s = plexServer.UriPlexBase.AbsoluteUri + "/video/:/transcode/segmented/" + s;

           string cookie = wc.ResponseHeaders[HttpResponseHeader.SetCookie];

           wc = new WebClient();

           try {
               if (cookie != null && cookie.Length > 0)
                   wc.Headers[HttpRequestHeader.Cookie] = cookie;

               s = wc.DownloadString(s);
           } catch (Exception x) {
             
           }

           s = s.Replace("/video", plexServer.UriPlexBase.AbsoluteUri + "/video");

           StreamWriter sw = File.CreateText("playlist.m3u8");
           sw.Write(s);
           sw.Flush();
           sw.Close();
           return m3u8Content;
       }

    }
}
