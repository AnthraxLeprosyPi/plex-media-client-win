using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlexMediaClient.Plex.Xml;

namespace PlexMediaClient.Plex {
    public class PlexServerCapabilities {

        public string FriendlyName { get; set; }
        public string PMSVersion { get; set; }
        public List<string> TranscoderBitrates { get; set; }
        public int SelectedBitrateIndex { get; set; }
        public List<string> TranscoderQualities { get; set; }
        public int SelectedQualityIndex { get; set; }
        public List<string> TranscoderVideoResolutions { get; set; }
        public int SelectedVideoResolutionIndex { get; set; }

        public PlexServerCapabilities() {

        }
        public PlexServerCapabilities(MediaContainer serverBaseUriResponse) {
            
            /* 
             * machineIdentifier="a1eca883f32bacf7cb3a68782088087425c258be" 
             * transcoderActiveVideoSessions="0" 
             * transcoderVideoBitrates="64,96,208,320,720,1500,2000,3000,4000,8000,10000,12000,20000" 
             * transcoderVideoQualities="0,1,2,3,4,5,6,7,8,9,10,11,12" 
             * transcoderVideoResolutions="128,128,160,240,320,480,768,720,720,1080,1080,1080,1080" 
             * version="0.9.2.6-acf9a75"
             
             */
        }

    }
}
