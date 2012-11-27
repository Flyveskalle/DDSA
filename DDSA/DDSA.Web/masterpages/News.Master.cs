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
    public partial class News : TemplateBase<TextPageDoctType>
    {

        public string NewsletterHtml = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            NewsletterHtml = new NewsletterManager().RenderNewsletter(1158);
            
            TextPageDoctType current = ContentHelper.GetCurrentContent() as TextPageDoctType;
            uiUcTagList.Tags = current.Tags.Split(',').ToList();
        }
    }
}