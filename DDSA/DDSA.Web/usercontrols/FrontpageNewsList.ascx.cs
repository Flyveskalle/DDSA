using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DDSA.Backend.Business;

namespace DDSA.Web.usercontrols
{
    public partial class FrontpageNewsList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            uiRptFrontpageNews.DataSource = new DualShockManager().GetFrontpageNewsList();
            uiRptFrontpageNews.DataBind();
        }
    }
}
