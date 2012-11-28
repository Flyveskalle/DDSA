using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vega.USiteBuilder;
using DDSA.Backend.Business.Tabs;
namespace DDSA.Backend.Business.DocTypes
{
    [DocumentType(Name="BasePage")]
    public class BasePageType : Vega.USiteBuilder.DocumentTypeBase
    {
        [DocumentTypeProperty(UmbracoPropertyType.Textstring, Name = "Overskrift", Tab = CmsTabs.Indhold)]
        public string Headline { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.SimpleEditor, Name = "Meta Keywords", Tab = CmsTabs.SEO)]
        public string MetaKeywords { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.SimpleEditor, Name = "Meta Description", Tab = CmsTabs.SEO)]
        public string MetaDescription { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.TrueFalse, Name = "Skjul i menu?")]
        public bool umbracoNaviHide { get; set; }
    }
}
