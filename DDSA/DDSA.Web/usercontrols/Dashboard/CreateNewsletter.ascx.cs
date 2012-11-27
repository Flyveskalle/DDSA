using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DDSA.Backend.Business;

namespace DDSA.Web.usercontrols.Dashboard
{
    public partial class CreateNewsletter : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                uiRptNewslist.DataSource = new DualShockManager().GetNews();
                uiRptNewslist.DataBind();

                uiRptMedia.DataSource = new NewsletterManager().BannersForNewsletter();
                uiRptMedia.DataBind();
            }
        }
    }
}