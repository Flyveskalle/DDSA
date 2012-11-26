using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vega.USiteBuilder;
using DDSA.Backend.Business.Tabs;

namespace DDSA.Backend.Business.DocTypes
{
    [DocumentType(Name = "Tekstside", Description = "Almindelig tesktide der bruges til nyheder, FAQ etc.")]
    public class TextPageDoctType : BasePageType
    {
        [DocumentTypeProperty(UmbracoPropertyType.Upload, Name = "Billede", Description = "Upload nyt billede", Tab = CmsTabs.Indhold)]
        public string ImageUpload { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.SimpleEditor, Name = "Kort beskrivelse", Tab = CmsTabs.Indhold)]
        public string ShortDescription { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.RichtextEditor, Name = "Beskrivelse", Tab = CmsTabs.Indhold)]
        public string Description { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.RelatedLinks, Name = "Relaterede links", Tab = CmsTabs.Indhold)]
        public string RelatedLinks { get; set; }

        public string ImageUrl
        {
            get
            {
                if(!string.IsNullOrEmpty(ImageUpload)){}
                //DualShockManager.GetImageUrlFromId()
                return "";
            }

        }
    }
}
