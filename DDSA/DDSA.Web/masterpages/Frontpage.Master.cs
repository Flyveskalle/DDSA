using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DDSA.Backend.Business;
using DDSA.Backend.Business.DocTypes;
using umbraco.NodeFactory;
using Vega.USiteBuilder;

namespace DDSA.Web.masterpages
{
    public partial class Frontpage : TemplateBase<FrontpageDocType>
    {
        public TimeSpan CountDownTimes { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            CountDownTimes = new DualShockManager().SimpleSettingsPageDocType.CountdownTime.Subtract(DateTime.Now);
        }

        public string BreadCrumb()
        {
            StringBuilder sb = new StringBuilder();
            foreach (int id in ContentHelper.GetCurrentContent().Path)
            {
                if (id != -1 && id != ContentHelper.GetCurrentContent().Id)
                {
                    if (id == new DualShockManager().SimpleSettingsPageDocType.Homepage)
                    {
                        sb.Append(new Node().Name);
                    }
                    else
                    {
                        sb.Append(new Node(id).Name);
                        sb.Append(" :: ");
                    }
                }
            }
            sb.Append(ContentHelper.GetCurrentContent().Id);
            return sb.ToString();
        }
    }
}