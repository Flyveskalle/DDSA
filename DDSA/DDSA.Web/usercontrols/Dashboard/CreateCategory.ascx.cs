using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DDSA.Backend.Business;
using DDSA.Backend.Business.DocTypes;
using umbraco.cms.businesslogic.web;

namespace DDSA.Web.usercontrols.Dashboard
{
    public partial class CreateCategory : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void uiBtnCreateCategoryClick(object sender, EventArgs e)
        {
            uiLblMessage.Text = new DualShockManager().CreateCategory(uiTxtCategoryName.Text);
        }
    }
}