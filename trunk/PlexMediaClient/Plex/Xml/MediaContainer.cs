using System.Xml.Serialization;
namespace PlexMediaClient.Plex.Xml {


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class MediaContainer {

        private System.Collections.Generic.List<MediaContainerDirectory> directoryField;

        private System.Collections.Generic.List<MediaContainerVideo> videoField;

        private string sizeField;

        private string mediaTagPrefixField;

        private string mediaTagVersionField;

        private string title1Field;

        private string identifierField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Directory", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.Collections.Generic.List<MediaContainerDirectory> Directory {
            get {
                return this.directoryField;
            }
            set {
                this.directoryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Video", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.Collections.Generic.List<MediaContainerVideo> Video {
            get {
                return this.videoField;
            }
            set {
                this.videoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string size {
            get {
                return this.sizeField;
            }
            set {
                this.sizeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string mediaTagPrefix {
            get {
                return this.mediaTagPrefixField;
            }
            set {
                this.mediaTagPrefixField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string mediaTagVersion {
            get {
                return this.mediaTagVersionField;
            }
            set {
                this.mediaTagVersionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string title1 {
            get {
                return this.title1Field;
            }
            set {
                this.title1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string identifier {
            get {
                return this.identifierField;
            }
            set {
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MediaContainerDirectory {

        private System.Collections.Generic.List<MediaContainerDirectoryLocation> locationField;

        private string refreshingField;

        private string keyField;

        private string typeField;

        private string titleField;

        private string artField;

        private string agentField;

        private string scannerField;

        private string languageField;

        private string updatedAtField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Location", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.Collections.Generic.List<MediaContainerDirectoryLocation> Location {
            get {
                return this.locationField;
            }
            set {
                this.locationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string refreshing {
            get {
                return this.refreshingField;
            }
            set {
                this.refreshingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string art {
            get {
                return this.artField;
            }
            set {
                this.artField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string agent {
            get {
                return this.agentField;
            }
            set {
                this.agentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string scanner {
            get {
                return this.scannerField;
            }
            set {
                this.scannerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string language {
            get {
                return this.languageField;
            }
            set {
                this.languageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string updatedAt {
            get {
                return this.updatedAtField;
            }
            set {
                this.updatedAtField = value;
            }
        }

        [XmlIgnore]
        public MediaContainer ChildContainer { get; set; }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MediaContainerDirectoryLocation {

        private string pathField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string path {
            get {
                return this.pathField;
            }
            set {
                this.pathField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MediaContainerVideo {

        private System.Collections.Generic.List<MediaContainerVideoMedia> mediaField;

        private System.Collections.Generic.List<MediaContainerVideoGenre> genreField;

        private System.Collections.Generic.List<MediaContainerVideoDirector> directorField;

        private System.Collections.Generic.List<MediaContainerVideoRole> roleField;

        private string ratingKeyField;

        private string keyField;

        private string typeField;

        private string titleField;

        private string summaryField;

        private string yearField;

        private string taglineField;

        private string thumbField;

        private string artField;

        private string durationField;

        private string originallyAvailableAtField;

        private string updatedAtField;

        private string studioField;

        private string contentRatingField;

        private string titleSortField;

        private string ratingField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Media", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.Collections.Generic.List<MediaContainerVideoMedia> Media {
            get {
                return this.mediaField;
            }
            set {
                this.mediaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Genre", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.Collections.Generic.List<MediaContainerVideoGenre> Genre {
            get {
                return this.genreField;
            }
            set {
                this.genreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Director", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.Collections.Generic.List<MediaContainerVideoDirector> Director {
            get {
                return this.directorField;
            }
            set {
                this.directorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Role", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.Collections.Generic.List<MediaContainerVideoRole> Role {
            get {
                return this.roleField;
            }
            set {
                this.roleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ratingKey {
            get {
                return this.ratingKeyField;
            }
            set {
                this.ratingKeyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string summary {
            get {
                return this.summaryField;
            }
            set {
                this.summaryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string year {
            get {
                return this.yearField;
            }
            set {
                this.yearField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string tagline {
            get {
                return this.taglineField;
            }
            set {
                this.taglineField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string thumb {
            get {
                return this.thumbField;
            }
            set {
                this.thumbField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string art {
            get {
                return this.artField;
            }
            set {
                this.artField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string duration {
            get {
                return this.durationField;
            }
            set {
                this.durationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string originallyAvailableAt {
            get {
                return this.originallyAvailableAtField;
            }
            set {
                this.originallyAvailableAtField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string updatedAt {
            get {
                return this.updatedAtField;
            }
            set {
                this.updatedAtField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string studio {
            get {
                return this.studioField;
            }
            set {
                this.studioField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string contentRating {
            get {
                return this.contentRatingField;
            }
            set {
                this.contentRatingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string titleSort {
            get {
                return this.titleSortField;
            }
            set {
                this.titleSortField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string rating {
            get {
                return this.ratingField;
            }
            set {
                this.ratingField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MediaContainerVideoMedia {

        private System.Collections.Generic.List<MediaContainerVideoMediaPart> partField;

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
        [System.Xml.Serialization.XmlElementAttribute("Part", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.Collections.Generic.List<MediaContainerVideoMediaPart> Part {
            get {
                return this.partField;
            }
            set {
                this.partField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string duration {
            get {
                return this.durationField;
            }
            set {
                this.durationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string bitrate {
            get {
                return this.bitrateField;
            }
            set {
                this.bitrateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string aspectRatio {
            get {
                return this.aspectRatioField;
            }
            set {
                this.aspectRatioField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string audioChannels {
            get {
                return this.audioChannelsField;
            }
            set {
                this.audioChannelsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string audioCodec {
            get {
                return this.audioCodecField;
            }
            set {
                this.audioCodecField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string videoCodec {
            get {
                return this.videoCodecField;
            }
            set {
                this.videoCodecField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string videoResolution {
            get {
                return this.videoResolutionField;
            }
            set {
                this.videoResolutionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string container {
            get {
                return this.containerField;
            }
            set {
                this.containerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string videoFrameRate {
            get {
                return this.videoFrameRateField;
            }
            set {
                this.videoFrameRateField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MediaContainerVideoMediaPart {

        private string keyField;

        private string durationField;

        private string fileField;

        private string sizeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string duration {
            get {
                return this.durationField;
            }
            set {
                this.durationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string file {
            get {
                return this.fileField;
            }
            set {
                this.fileField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string size {
            get {
                return this.sizeField;
            }
            set {
                this.sizeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MediaContainerVideoGenre {

        private string tagField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string tag {
            get {
                return this.tagField;
            }
            set {
                this.tagField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MediaContainerVideoDirector {

        private string tagField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string tag {
            get {
                return this.tagField;
            }
            set {
                this.tagField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MediaContainerVideoRole {

        private string tagField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string tag {
            get {
                return this.tagField;
            }
            set {
                this.tagField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class NewDataSet {

        private System.Collections.Generic.List<MediaContainer> itemsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MediaContainer")]
        public System.Collections.Generic.List<MediaContainer> Items {
            get {
                return this.itemsField;
            }
            set {
                this.itemsField = value;
            }
        }
    }
}
