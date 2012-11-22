using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vega.USiteBuilder;

namespace DDSA.Backend.Business.DocTypes
{
    [DocumentType(Name = "Mediaside", Description = "Side til visning af video eller billeder eller til afspilning af lyd-fil")]
    public class MediaDocType : BasePageType
    {
        [DocumentTypeProperty(UmbracoPropertyType.Upload, Name = "Billede", Description = "Upload et billede", Tab = Tabs.CmsTabs.Indhold)]
        public int Image { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.Textstring, Name = "Video", Description = "Url til video fra f.eks. Youtube", Tab = Tabs.CmsTabs.Indhold)]
        public string VideoUrl { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.Upload, Name = "Musik", Description = "Upload en mp3 fil", Tab = Tabs.CmsTabs.Indhold)]
        public string MusicFileUrl { get; set; }
    }
}
