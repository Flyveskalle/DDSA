using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vega.USiteBuilder;

namespace DDSA.Backend.Business.DocTypes
{
    [DocumentType(Name = "Nominerings Listeside", Description = "Denne side bruges til at liste alt hvad den nomineret har på siden", IconUrl = "Artists.ico")]
    public class NominiesListDocType : BasePageType
    {
        [DocumentTypeProperty(UmbracoPropertyType.Tags , Name = "Nomineret", Tab = Tabs.CmsTabs.Indhold, Description = "Vælg nomineret fra listen / skriv nomineret")]
        public string Nominated { get; set; }

    }
}
