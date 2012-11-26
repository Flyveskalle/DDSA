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

        [DocumentTypeProperty(UmbracoPropertyType.DatePickerWithTime, Name = "Nedtællings dato", Description = "Vælg den dato der skal tælles ned fra", Tab = CmsTabs.Konfiguration)]
        public DateTime CountdownTime { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.Textstring, Name = "Facebook side", Tab = CmsTabs.Konfiguration)]
        public string FacebookPage { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.ContentPicker, Name = "Nyhedsmappe", Tab = CmsTabs.Konfiguration)]
        public int NewsFolderId{ get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.ContentPicker, Name = "Kategorimappe", Tab = CmsTabs.Konfiguration)]
        public int CategoryFolderId { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.ContentPicker, Name = "Nomineredemappe", Tab = CmsTabs.Konfiguration)]
        public int NominiesFolderId{ get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.SimpleEditor, Name = "Tak for nyhedsbrevs tilmelding", Tab = CmsTabs.Email)]
        public string NewsletterSignUpMessage { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.MediaPicker, Name = "Medie Artist mappe", Tab = CmsTabs.Media)]
        public int MediaArtistFolderId { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.ContentPicker, Name = "Nyhedsbrevs mappe", Tab = CmsTabs.Newsletter)]
        public int NewsletterFolderId{ get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.MediaPicker, Name = "Bannere til nyhedsbrev", Tab = CmsTabs.Newsletter)]
        public int BannersForNewsletter { get; set; }
    }
}
