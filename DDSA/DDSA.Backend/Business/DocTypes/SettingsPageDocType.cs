using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vega.USiteBuilder;
using DDSA.Backend.Business.Tabs;

namespace DDSA.Backend.Business.DocTypes
{
    [DocumentType(Name = "Konfigurations Side")]
    public class SettingsPageDocType : DocumentTypeBase
    {
        [DocumentTypeProperty(UmbracoPropertyType.ContentPicker, Name = "Startside", Description = "Skal pege på Startsiden. Referencepunkt til resten af sites konfiguration", Tab = CmsTabs.Konfiguration)]
        public int Homepage { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.Textstring, Name = "Google Analytics Code", Tab = CmsTabs.SEO)]
        public string GoogleAnalyticsCode { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.DatePickerWithTime, Name = "Nedtællings dato",Description = "Vælg den dato der skal tælles ned fra", Tab = CmsTabs.Indhold)]
        public DateTime CountdownTime { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.Textstring, Name = "Facebook side", Tab = CmsTabs.Indhold)]
        public string FacebookPage { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.ContentPicker, Name = "Nyhedsmappe", Tab = CmsTabs.Indhold)]
        public int NewsFolderId{ get; set; }
    }
}
