using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDSA.Backend.Business.DataObjects;
using DDSA.Backend.Business.DocTypes;
using umbraco;
using umbraco.BusinessLogic;
using umbraco.cms.businesslogic.media;
using umbraco.cms.businesslogic.web;
using Vega.USiteBuilder;

namespace DDSA.Backend.Business
{
    public class NewsletterManager
    {


        public List<Media> BannersForNewsletter()
        {
            return new Media(new DualShockManager().SimpleSettingsPageDocType.BannersForNewsletter).Children.FirstOrDefault(x => x.Text == "475x145").Children.ToList();
        }

        public string SaveNewsletter(string newsletterItems, DateTime sendDate)
        {
            string[] newsletterArray = newsletterItems.Split('|');

            if (newsletterArray.Length > 0)
            {
                string newsLetterName = "Nyhedsbrev " + DateTime.Now.ToShortDateString();
                DocumentType dt = new DualShockManager().GetDocumentTypeByName("NewsletterDocType");
                Document newsLetter = Document.MakeNew(newsLetterName, dt, User.GetCurrent(),
                                                       new DualShockManager().SimpleSettingsPageDocType.NewsletterFolderId);
                int length = 1;
                string propertyValue = "";
                foreach (string array in newsletterArray)
                {
                    int id;

                    if (int.TryParse(array.Split(',')[0], out id))
                    {
                        string type = array.Split(',')[1] == "true" ? "nyhed" : "banner";
                        string item = NewsletterDataFormat(id, type, length == newsletterArray.Length);
                        propertyValue += item;
                    }

                    length++;
                }
                newsLetter.getProperty("newsletterData").Value = propertyValue;
                newsLetter.getProperty("sendDate").Value = sendDate;
                newsLetter.Publish(User.GetCurrent());
                library.UpdateDocumentCache(newsLetter.Id);

                return "Nyhedsbrevet : " + newsLetterName;
            }
            return "Der skete en fejl under oprettelsen af nyhedsbrevet";
        }

        public static string NewsletterDataFormat(int id, string type, bool isLast)
        {
            return string.Format("{0},{1}{2}", id, type, isLast ? "" : "|");
        }

        public string RenderNewsletter(int newsletterId)
        {
            NewsletterDocType newsletter = ContentHelper.GetByNodeId<NewsletterDocType>(newsletterId);
            var list = new List<NewsletterItem>();
            StringBuilder sb = new StringBuilder();
            
            foreach (string item in newsletter.NewsletterData.Split('|'))
            {
                int id;
                if (item.Split(',')[1] == "nyhed")
                {
                    if (int.TryParse(item.Split(',')[0], out id))
                    {
                        NewsletterItem newsletterItem = ConvertToNewsletterItem(id, item.Split(',')[1]);
                        sb.Append(RenderNewsletter(newsletterItem));
                    }
                }
            }
            return sb.ToString();
        }

        private NewsletterItem ConvertToNewsletterItem(int id, string type)
        {
            NewsletterType thisType = GetType(type);
            NewsletterItem nli = new NewsletterItem();
            if (thisType == NewsletterType.News)
            {
                TextPageDoctType news = new DualShockManager().GetNews(id);
                nli.Headline = news.Headline;
                nli.Content = news.Description;
                nli.ImageUrl = news.ImageUpload;    
            }

            if(thisType == NewsletterType.Banner)
            {
                nli.ImageUrl = DualShockManager.GetImageUrlFromId(id);
                nli.Type = thisType;
                nli.LinkUrl = "";
            }

            return nli;
        }

        

        public string RenderNewsletter(NewsletterItem newsletterItem)
        {
            if (newsletterItem.Type == NewsletterType.News)
            {
                return RenderNews(newsletterItem.Content, newsletterItem.ImageUrl, newsletterItem.LinkUrl);
            }
            return "";
        }

        private NewsletterType GetType(string type)
        {
            switch (type)
            {
                case "nyhed":
                    return NewsletterType.News;
                case "banner":
                    return NewsletterType.Banner;
                default:
                    return NewsletterType.Unknown;
            }
        }

        private string RenderNews(string content, string imgUrl, string linkUrl)
        {

            /*
             * <tr>
            <td>
                <img src="Images/WebGraphics/fish-food_1224_549_100.jpg" width="300px" />
            </td>
            <td  class="newsff">
                 <p>Selv om hun har sat alt mere frem, og derfor ikke længere kan betragtes som den
                                glade giver, er det en nem sammenstilling, som bærer ved i lang tid.
                                 Selv om hun har sat alt mere frem, og derfor ikke længere kan betragtes som den
                                glade giver, er det en nem sammenstilling, som bærer ved i lang tid.
                                 Selv om hun har sat alt mere frem, og derfor ikke længere kan betragtes som den
                                glade giver, er det en nem sammenstilling, som bærer ved i lang tid.</p>
                                <span class="link">
                                    <a href="#">Læs hele nyheden..</a>
                                </span>
            </td>
        </tr>
        <tr>
            <td class="spacer" colspan="2"></td>
        </tr>
             */
            StringBuilder sb = new StringBuilder();
            sb.Append("<tr>");
            sb.Append("<td>");

            sb.Append("<img class='newsimage' src=");
            sb.Append("'" + imgUrl + "'");
            sb.Append("</td>");
            sb.Append("<td class='news'>");
            sb.Append(content);
            sb.Append("<span class='link'><a href=");
            sb.Append("'" + linkUrl + "'</a>");
            sb.Append("Læs mere her...");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("<tr><td class='spacer' colspan='2'></td></tr>");
            return sb.ToString();
        }
    }
}
