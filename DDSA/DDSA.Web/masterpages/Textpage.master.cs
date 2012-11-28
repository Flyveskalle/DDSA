using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vega.USiteBuilder;
using DDSA.Backend.Business.DocTypes;

namespace DDSA.Web.masterpages
{
    public partial class Textpage : TemplateBase<TextPageDoctType>
    {
        public TextPageDoctType currentPage;

        protected void Page_Load(object sender, EventArgs e)
        {
            currentPage = ContentHelper.GetCurrentContent() as TextPageDoctType;
        }
    }
}