using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vega.USiteBuilder;

namespace DDSA.Backend.Business.DocTypes
{
    [DocumentType(Name = "Mappe")]
    public class FolderDocType : DocumentTypeBase
    {
        [DocumentTypeProperty(UmbracoPropertyType.TrueFalse, Name = "Vis i menu?")]
        public bool umbracoNaviHide { get; set; }
    }
}
