using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DDSA.Backend.Business;

namespace DDSA.Web.usercontrols
{
    public partial class NewsletterSignup : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnNewsletterSignUpClick(object sender, EventArgs e )
        {
            uiLblNewsletterSignUpMessage.Text =
                new DualShockManager().CreateMember(uiTxtNewsletterSignUpName.Text.Trim(),
                                                    uiTxtNewsletterSignUpEmail.Text.Trim().ToLower());

        }
    }
}