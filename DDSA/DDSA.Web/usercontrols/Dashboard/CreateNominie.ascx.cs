using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DDSA.Backend.Business;

namespace DDSA.Web.usercontrols.Dashboard
{
    public partial class CreateNominie : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void uiBtnCreateArtistClick(object sender, EventArgs e)
        {
            uiLblMessage.Text = new DualShockManager().CreateArtist(uiTxtNominieName.Text);
        }
    }
}