using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDSA.Backend.Business.Tabs;
using Vega.USiteBuilder;


namespace DDSA.Backend.Business.DocTypes
{
    [DocumentType(Name = "Kategori")]
    public class CategoryDocType : BasePageType
    {
        [DocumentTypeProperty(UmbracoPropertyType.SimpleEditor, Name = "Kort beskrivelse", Tab = CmsTabs.Indhold)]
        public string ShortDescription { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.RichtextEditor, Name = "Beskrivelse", Tab = CmsTabs.Indhold)]
        public string Description { get; set; }
    }
}
