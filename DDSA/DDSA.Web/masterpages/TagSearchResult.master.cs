using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DDSA.Backend.Business;
using DDSA.Backend.Business.DocTypes;
using Vega.USiteBuilder;

namespace DDSA.Web.masterpages
{
    public partial class TagSearchResult : TemplateBase<TagSearchDocType>
    {
        public string Tag { get; set; }
        public int SearchCount { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            string tag = Request.QueryString["tag"];
            if(!string.IsNullOrEmpty(tag) && !IsPostBack)
            {
                uiPlhTagResults.Visible = true;
                Tag = Request.QueryString["tag"].ToUpperInvariant();
                
                uiRptTagSearchResults.DataSource = new TagManager().GetResultsFromTagSearch(Tag.ToLower());
                uiRptTagSearchResults.DataBind();
                uiRptTagSearchResults.ItemDataBound += new RepeaterItemEventHandler(uiRptTagSearchResults_ItemDataBound);
            }
        }

        protected void uiRptTagSearchResults_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Footer && e.Item.ItemType != ListItemType.Header)
            {
                if (e.Item.DataItem is TextPageDoctType)
                { 
                    //Use specefic text-icon

                }

                if (e.Item.DataItem is NominiesDocType)
                {
                    //Use specefic Artist-icon
                }
            }
        }
    }
}