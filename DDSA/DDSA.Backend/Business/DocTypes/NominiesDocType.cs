using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vega.USiteBuilder;
using DDSA.Backend.Business.Tabs;

namespace DDSA.Backend.Business.DocTypes
{
    [DocumentType(Name = "Nominerede", Description = "Sidetype til at udfylde standard data omkring en artist, band el. andet enhed", IconUrl = "an_artist.ico")]
    public class NominiesDocType : BasePageType
    {
        [DocumentTypeProperty(UmbracoPropertyType.Upload, Name = "Billede", Description = "Upload nyt billede", Tab = CmsTabs.Indhold)]
        public string ImageUpload { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.SimpleEditor, Name = "Kort beskrivelse", Tab = CmsTabs.Indhold)]
        public string ShortDescription { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.RichtextEditor, Name = "Beskrivelse", Tab = CmsTabs.Indhold)]
        public string Description { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.TrueFalse, Name = "Forhåndsfavorit", Tab = CmsTabs.Indhold, DefaultValue = false)]
        public string Favorites { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.RelatedLinks, Name = "Relaterede links", Tab = CmsTabs.Indhold)]
        public string RelatedLinks { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.Textstring, Name = "Youtube kanal",Description = "Link til Youtube kanal", Tab = CmsTabs.Indhold)]
        public string YoutubeChannel { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.MediaPicker, Name = "Mediamappe", Description = "Link mediamappen", Tab = CmsTabs.Indhold)]
        public string MediaFolderNodeId { get; set; }



    }
}
