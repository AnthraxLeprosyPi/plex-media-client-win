using System.Xml.Serialization;
namespace PlexMediaClient.Plex.Xml
{
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class Genre
    {
        
        private string tagField;
        
        private string idField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string tag
        {
            get
            {
                return this.tagField;
            }
            set
            {
                this.tagField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class Media
    {
        
        private System.Collections.Generic.List<MediaPart> partField;
        
        private string idField;
        
        private string durationField;
        
        private string bitrateField;
        
        private string aspectRatioField;
        
        private string audioChannelsField;
        
        private string audioCodecField;
        
        private string videoCodecField;
        
        private string videoResolutionField;
        
        private string containerField;
        
        private string videoFrameRateField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Part", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public System.Collections.Generic.List<MediaPart> Part
        {
            get
            {
                return this.partField;
            }
            set
            {
                this.partField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string bitrate
        {
            get
            {
                return this.bitrateField;
            }
            set
            {
                this.bitrateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string aspectRatio
        {
            get
            {
                return this.aspectRatioField;
            }
            set
            {
                this.aspectRatioField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string audioChannels
        {
            get
            {
                return this.audioChannelsField;
            }
            set
            {
                this.audioChannelsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string audioCodec
        {
            get
            {
                return this.audioCodecField;
            }
            set
            {
                this.audioCodecField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string videoCodec
        {
            get
            {
                return this.videoCodecField;
            }
            set
            {
                this.videoCodecField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string videoResolution
        {
            get
            {
                return this.videoResolutionField;
            }
            set
            {
                this.videoResolutionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string container
        {
            get
            {
                return this.containerField;
            }
            set
            {
                this.containerField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string videoFrameRate
        {
            get
            {
                return this.videoFrameRateField;
            }
            set
            {
                this.videoFrameRateField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class MediaPart
    {
        
        private System.Collections.Generic.List<MediaPartStream> streamField;
        
        private string idField;
        
        private string keyField;
        
        private string durationField;
        
        private string fileField;
        
        private string sizeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Stream", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public System.Collections.Generic.List<MediaPartStream> Stream
        {
            get
            {
                return this.streamField;
            }
            set
            {
                this.streamField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string file
        {
            get
            {
                return this.fileField;
            }
            set
            {
                this.fileField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string size
        {
            get
            {
                return this.sizeField;
            }
            set
            {
                this.sizeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class MediaPartStream
    {
        
        private string idField;
        
        private string streamTypeField;
        
        private string codecField;
        
        private string indexField;
        
        private string selectedField;
        
        private string keyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string streamType
        {
            get
            {
                return this.streamTypeField;
            }
            set
            {
                this.streamTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string codec
        {
            get
            {
                return this.codecField;
            }
            set
            {
                this.codecField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string index
        {
            get
            {
                return this.indexField;
            }
            set
            {
                this.indexField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string selected
        {
            get
            {
                return this.selectedField;
            }
            set
            {
                this.selectedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class MediaContainer
    {
        
        private System.Collections.Generic.List<MediaContainerDirectory> directoryField;
        
        private System.Collections.Generic.List<MediaContainerVideo> videoField;
        
        private System.Collections.Generic.List<MediaContainerTrack> trackField;
        
        private string sizeField;
        
        private string grandparentTitleField;
        
        private string mediaTagPrefixField;
        
        private string mediaTagVersionField;
        
        private string nocacheField;
        
        private string bannerField;
        
        private string parentIndexField;
        
        private string parentTitleField;
        
        private string parentYearField;
        
        private string thumbField;
        
        private string viewGroupField;
        
        private string viewModeField;
        
        private string keyField;
        
        private string artField;
        
        private string title1Field;
        
        private string title2Field;
        
        private string identifierField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Directory", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public System.Collections.Generic.List<MediaContainerDirectory> Directory
        {
            get
            {
                return this.directoryField;
            }
            set
            {
                this.directoryField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Video", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public System.Collections.Generic.List<MediaContainerVideo> Video
        {
            get
            {
                return this.videoField;
            }
            set
            {
                this.videoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Track", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public System.Collections.Generic.List<MediaContainerTrack> Track
        {
            get
            {
                return this.trackField;
            }
            set
            {
                this.trackField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string size
        {
            get
            {
                return this.sizeField;
            }
            set
            {
                this.sizeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string grandparentTitle
        {
            get
            {
                return this.grandparentTitleField;
            }
            set
            {
                this.grandparentTitleField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string mediaTagPrefix
        {
            get
            {
                return this.mediaTagPrefixField;
            }
            set
            {
                this.mediaTagPrefixField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string mediaTagVersion
        {
            get
            {
                return this.mediaTagVersionField;
            }
            set
            {
                this.mediaTagVersionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string nocache
        {
            get
            {
                return this.nocacheField;
            }
            set
            {
                this.nocacheField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string banner
        {
            get
            {
                return this.bannerField;
            }
            set
            {
                this.bannerField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string parentIndex
        {
            get
            {
                return this.parentIndexField;
            }
            set
            {
                this.parentIndexField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string parentTitle
        {
            get
            {
                return this.parentTitleField;
            }
            set
            {
                this.parentTitleField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string parentYear
        {
            get
            {
                return this.parentYearField;
            }
            set
            {
                this.parentYearField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string thumb
        {
            get
            {
                return this.thumbField;
            }
            set
            {
                this.thumbField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string viewGroup
        {
            get
            {
                return this.viewGroupField;
            }
            set
            {
                this.viewGroupField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string viewMode
        {
            get
            {
                return this.viewModeField;
            }
            set
            {
                this.viewModeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string art
        {
            get
            {
                return this.artField;
            }
            set
            {
                this.artField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string title1
        {
            get
            {
                return this.title1Field;
            }
            set
            {
                this.title1Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string title2
        {
            get
            {
                return this.title2Field;
            }
            set
            {
                this.title2Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string identifier
        {
            get
            {
                return this.identifierField;
            }
            set
            {
                this.identifierField = value;
            }
        }

        [XmlIgnore]
        public System.Uri UriSource { get; set; }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class MediaContainerDirectory
    {
        
        private System.Collections.Generic.List<MediaContainerDirectoryLocation> locationField;
        
        private System.Collections.Generic.List<Genre> genreField;
        
        private string ratingKeyField;
        
        private string keyField;
        
        private string studioField;
        
        private string typeField;
        
        private string titleField;
        
        private string contentRatingField;
        
        private string summaryField;
        
        private string indexField;
        
        private string ratingField;
        
        private string yearField;
        
        private string thumbField;
        
        private string artField;
        
        private string bannerField;
        
        private string durationField;
        
        private string originallyAvailableAtField;
        
        private string leafCountField;
        
        private string viewedLeafCountField;
        
        private string updatedAtField;
        
        private string promptField;
        
        private string searchField;
        
        private string refreshingField;
        
        private string agentField;
        
        private string scannerField;
        
        private string languageField;
        
        private string parentTitleField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Location", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public System.Collections.Generic.List<MediaContainerDirectoryLocation> Location
        {
            get
            {
                return this.locationField;
            }
            set
            {
                this.locationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Genre", Order=1)]
        public System.Collections.Generic.List<Genre> Genre
        {
            get
            {
                return this.genreField;
            }
            set
            {
                this.genreField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ratingKey
        {
            get
            {
                return this.ratingKeyField;
            }
            set
            {
                this.ratingKeyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string studio
        {
            get
            {
                return this.studioField;
            }
            set
            {
                this.studioField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contentRating
        {
            get
            {
                return this.contentRatingField;
            }
            set
            {
                this.contentRatingField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string summary
        {
            get
            {
                return this.summaryField;
            }
            set
            {
                this.summaryField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string index
        {
            get
            {
                return this.indexField;
            }
            set
            {
                this.indexField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string rating
        {
            get
            {
                return this.ratingField;
            }
            set
            {
                this.ratingField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string year
        {
            get
            {
                return this.yearField;
            }
            set
            {
                this.yearField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string thumb
        {
            get
            {
                return this.thumbField;
            }
            set
            {
                this.thumbField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string art
        {
            get
            {
                return this.artField;
            }
            set
            {
                this.artField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string banner
        {
            get
            {
                return this.bannerField;
            }
            set
            {
                this.bannerField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string originallyAvailableAt
        {
            get
            {
                return this.originallyAvailableAtField;
            }
            set
            {
                this.originallyAvailableAtField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string leafCount
        {
            get
            {
                return this.leafCountField;
            }
            set
            {
                this.leafCountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string viewedLeafCount
        {
            get
            {
                return this.viewedLeafCountField;
            }
            set
            {
                this.viewedLeafCountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string updatedAt
        {
            get
            {
                return this.updatedAtField;
            }
            set
            {
                this.updatedAtField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string prompt
        {
            get
            {
                return this.promptField;
            }
            set
            {
                this.promptField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string search
        {
            get
            {
                return this.searchField;
            }
            set
            {
                this.searchField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string refreshing
        {
            get
            {
                return this.refreshingField;
            }
            set
            {
                this.refreshingField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string agent
        {
            get
            {
                return this.agentField;
            }
            set
            {
                this.agentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string scanner
        {
            get
            {
                return this.scannerField;
            }
            set
            {
                this.scannerField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string language
        {
            get
            {
                return this.languageField;
            }
            set
            {
                this.languageField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string parentTitle
        {
            get
            {
                return this.parentTitleField;
            }
            set
            {
                this.parentTitleField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class MediaContainerDirectoryLocation
    {
        
        private string pathField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string path
        {
            get
            {
                return this.pathField;
            }
            set
            {
                this.pathField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class MediaContainerVideo
    {
        
        private System.Collections.Generic.List<Media> mediaField;
        
        private System.Collections.Generic.List<Genre> genreField;
        
        private System.Collections.Generic.List<MediaContainerVideoDirector> directorField;
        
        private System.Collections.Generic.List<MediaContainerVideoField> fieldField;
        
        private string ratingKeyField;
        
        private string keyField;
        
        private string guidField;
        
        private string studioField;
        
        private string typeField;
        
        private string titleField;
        
        private string contentRatingField;
        
        private string summaryField;
        
        private string ratingField;
        
        private string yearField;
        
        private string taglineField;
        
        private string thumbField;
        
        private string artField;
        
        private string durationField;
        
        private string originallyAvailableAtField;
        
        private string addedAtField;
        
        private string updatedAtField;
        
        private string grandparentKeyField;
        
        private string grandparentTitleField;
        
        private string indexField;
        
        private string parentIndexField;
        
        private string viewOffsetField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Media", Order=0)]
        public System.Collections.Generic.List<Media> Media
        {
            get
            {
                return this.mediaField;
            }
            set
            {
                this.mediaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Genre", Order=1)]
        public System.Collections.Generic.List<Genre> Genre
        {
            get
            {
                return this.genreField;
            }
            set
            {
                this.genreField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Director", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public System.Collections.Generic.List<MediaContainerVideoDirector> Director
        {
            get
            {
                return this.directorField;
            }
            set
            {
                this.directorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Field", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public System.Collections.Generic.List<MediaContainerVideoField> Field
        {
            get
            {
                return this.fieldField;
            }
            set
            {
                this.fieldField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ratingKey
        {
            get
            {
                return this.ratingKeyField;
            }
            set
            {
                this.ratingKeyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string guid
        {
            get
            {
                return this.guidField;
            }
            set
            {
                this.guidField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string studio
        {
            get
            {
                return this.studioField;
            }
            set
            {
                this.studioField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contentRating
        {
            get
            {
                return this.contentRatingField;
            }
            set
            {
                this.contentRatingField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string summary
        {
            get
            {
                return this.summaryField;
            }
            set
            {
                this.summaryField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string rating
        {
            get
            {
                return this.ratingField;
            }
            set
            {
                this.ratingField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string year
        {
            get
            {
                return this.yearField;
            }
            set
            {
                this.yearField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string tagline
        {
            get
            {
                return this.taglineField;
            }
            set
            {
                this.taglineField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string thumb
        {
            get
            {
                return this.thumbField;
            }
            set
            {
                this.thumbField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string art
        {
            get
            {
                return this.artField;
            }
            set
            {
                this.artField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string originallyAvailableAt
        {
            get
            {
                return this.originallyAvailableAtField;
            }
            set
            {
                this.originallyAvailableAtField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string addedAt
        {
            get
            {
                return this.addedAtField;
            }
            set
            {
                this.addedAtField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string updatedAt
        {
            get
            {
                return this.updatedAtField;
            }
            set
            {
                this.updatedAtField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string grandparentKey
        {
            get
            {
                return this.grandparentKeyField;
            }
            set
            {
                this.grandparentKeyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string grandparentTitle
        {
            get
            {
                return this.grandparentTitleField;
            }
            set
            {
                this.grandparentTitleField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string index
        {
            get
            {
                return this.indexField;
            }
            set
            {
                this.indexField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string parentIndex
        {
            get
            {
                return this.parentIndexField;
            }
            set
            {
                this.parentIndexField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string viewOffset
        {
            get
            {
                return this.viewOffsetField;
            }
            set
            {
                this.viewOffsetField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class MediaContainerVideoDirector
    {
        
        private string idField;
        
        private string tagField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string tag
        {
            get
            {
                return this.tagField;
            }
            set
            {
                this.tagField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class MediaContainerVideoField
    {
        
        private string nameField;
        
        private string lockedField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string locked
        {
            get
            {
                return this.lockedField;
            }
            set
            {
                this.lockedField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class MediaContainerTrack
    {
        
        private System.Collections.Generic.List<Media> mediaField;
        
        private string ratingKeyField;
        
        private string keyField;
        
        private string typeField;
        
        private string titleField;
        
        private string summaryField;
        
        private string indexField;
        
        private string durationField;
        
        private string updatedAtField;
        
        private string guidField;
        
        private string addedAtField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Media", Order=0)]
        public System.Collections.Generic.List<Media> Media
        {
            get
            {
                return this.mediaField;
            }
            set
            {
                this.mediaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ratingKey
        {
            get
            {
                return this.ratingKeyField;
            }
            set
            {
                this.ratingKeyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string summary
        {
            get
            {
                return this.summaryField;
            }
            set
            {
                this.summaryField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string index
        {
            get
            {
                return this.indexField;
            }
            set
            {
                this.indexField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string updatedAt
        {
            get
            {
                return this.updatedAtField;
            }
            set
            {
                this.updatedAtField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string guid
        {
            get
            {
                return this.guidField;
            }
            set
            {
                this.guidField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string addedAt
        {
            get
            {
                return this.addedAtField;
            }
            set
            {
                this.addedAtField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class NewDataSet
    {
        
        private System.Collections.Generic.List<object> itemsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Genre", typeof(Genre), Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("Media", typeof(Media), Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("MediaContainer", typeof(MediaContainer), Order=0)]
        public System.Collections.Generic.List<object> Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }
}
