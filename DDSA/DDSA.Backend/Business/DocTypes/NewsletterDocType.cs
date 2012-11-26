using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDSA.Backend.Business.Tabs;
using Vega.USiteBuilder;

namespace DDSA.Backend.Business.DocTypes
{
    [DocumentType(Name = "Nyhedsbrev", Description = "Brug Byg Nyhedsbrevs funktionen til at oprette et nyhedsbrev")]
    public class NewsletterDocType : BasePageType
    {
        [DocumentTypeProperty(UmbracoPropertyType.SimpleEditor, Name = "Nyhedsbrevs data",
            Description = "Rediger med største forsigtighed!", Tab = CmsTabs.Indhold)]
        public string NewsletterData { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.DatePickerWithTime, Name = "Udsendelses dato m. tid",
            Description = "Det tidspunkt hvor nyhedsbrevet bliver send ud", Tab = CmsTabs.Indhold)]
        public DateTime SendDate { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.TrueFalse, Name = "Er nyhedsbrev udsend", Tab = CmsTabs.Indhold, DefaultValue = false)]
        public bool IsSend{ get; set; }

        

    }
}
