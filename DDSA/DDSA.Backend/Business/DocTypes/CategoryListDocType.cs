using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vega.USiteBuilder;
using DDSA.Backend.Business.Tabs;

namespace DDSA.Backend.Business.DocTypes
{
    [DocumentType(Name = "Kategori liste", Description = "Sidetype til at oprette en ny kategori", IconUrl = "categories.ico")]
    public class CategoryListDocType : BasePageType
    {
        [DocumentTypeProperty(UmbracoPropertyType.SimpleEditor, Name = "Kort beskrivelse", Tab = CmsTabs.Indhold)]
        public string ShortDescription { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.RichtextEditor, Name = "Beskrivelse", Tab = CmsTabs.Indhold)]
        public string Description { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.UltimatePicker, Name = "Vælg de Nominerede", Tab = CmsTabs.Indhold)]
        public string Nominies { get; set; }

    }
}
