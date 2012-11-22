using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DDSA.Backend.Business;

namespace DDSA.Web.usercontrols.Dashboard
{
    public partial class CreateNews : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void uiBtnCreateNewsClick(object sender, EventArgs e)
        {
            int id = new DualShockManager().CreateNews(uiTxtNewsName.Text.Trim(), uiChbShowInMenu.Checked, uiChbPublish.Checked);
            if(id != -1)
            {
                Response.Redirect("/umbraco/editContent.aspx?id=" + id);
            }
        }
    }
}