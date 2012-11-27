using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vega.USiteBuilder;
using DDSA.Backend.Business;
using DDSA.Backend.Business.DocTypes;

namespace DDSA.Web.usercontrols
{
    public partial class TextPageTags : System.Web.UI.UserControl
    {
        public List<string> Tags { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                uiRptTags.DataSource = Tags;
                uiRptTags.DataBind();
            }
        }

        protected void uiBtnTagClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn != null)
            {
                string tag = btn.Text;
                
                
                Response.Redirect(ContentHelper.GetByNodeId<TagSearchDocType>(1169).NiceUrl+"?tag="+tag);
            }

        }
    }
}