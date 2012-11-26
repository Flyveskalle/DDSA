using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDSA.Backend.Business.DataObjects;
using DDSA.Backend.Business.DocTypes;
//using uComponents.Core;
using umbraco;
using umbraco.BusinessLogic;
using umbraco.cms.businesslogic.media;
using umbraco.cms.businesslogic.member;
using Vega.USiteBuilder;
//using uComponents.Core;
//using uComponents.DataTypes;
using umbraco.businesslogic;
using umbraco.cms.businesslogic.web;
using System.Web.Security;

namespace DDSA.Backend.Business
{
    public class DualShockManager
    {
        private SettingsPageDocType _settingsPageDocType;
        public SettingsPageDocType SettingsPageDocType
        {
            get
            {
                if (_settingsPageDocType == null)
                {
                    foreach (DocumentTypeBase child in ContentHelper.GetChildren(umbraco.uQuery.GetRootNode().Id, false))
                    {
                        if (child.NodeTypeAlias == "SettingsPageDocType")
                        {
                            _settingsPageDocType = ContentHelper.GetByNodeId<SettingsPageDocType>(child.Id);
                            break;
                        }
                    }
                }
                return _settingsPageDocType;
            }
            set
            {
                _settingsPageDocType = value;
            }
        }

        private SettingsPageDocType _simpleSettingsPageDocType;
        public SettingsPageDocType SimpleSettingsPageDocType
        {
            get
            {
                if (_simpleSettingsPageDocType == null)
                {
                    _simpleSettingsPageDocType = ContentHelper.GetChildren<SettingsPageDocType>(uQuery.GetRootNode().Id, false).FirstOrDefault(x => x is SettingsPageDocType);
                }
                return _simpleSettingsPageDocType;
            }
        }


        private FrontpageDocType _frontPage;
        public FrontpageDocType Frontpage
        {
            get
            {
                if (_frontPage == null)
                {
                    _frontPage = ContentHelper.GetByNodeId<FrontpageDocType>(SimpleSettingsPageDocType.Homepage);
                }
                return _frontPage;
            }


        }

        public List<TextPageDoctType> GetFrontpageNewsList()
        {
            var hej = ContentHelper.GetChildren<TextPageDoctType>(SimpleSettingsPageDocType.NewsFolderId).Where(x => x.Template == 1149).OrderByDescending(x => x.CreateDate).Take(5).ToList();
            return hej;
        }

        public List<TextPageDoctType> GetNews()
        {
            return ContentHelper.GetChildren<TextPageDoctType>(SimpleSettingsPageDocType.NewsFolderId).OrderByDescending(x => x.CreateDate).ToList();
        }

        public TextPageDoctType GetNews(int id)
        {
            var result = ContentHelper.GetChildren<TextPageDoctType>(SimpleSettingsPageDocType.NewsFolderId).FirstOrDefault(
                    x => x.Id == id);
            return result;
        }

        public CategoryListDocType GetCategoryListNode()
        {
            return ContentHelper.GetByNodeId<CategoryListDocType>(SimpleSettingsPageDocType.CategoryFolderId);
        }

        public NominiesListDocType GetNominiesListNode()
        {
            return ContentHelper.GetChildren(SimpleSettingsPageDocType.Homepage).Where(x => x is NominiesListDocType).FirstOrDefault() as NominiesListDocType;
        }

        public string CreateCategory(string categoryName)
        {
            //Locate Category node in umbraco tree
            CategoryListDocType categoryListDocType = new DualShockManager().GetCategoryListNode();
            if (categoryListDocType != null)
            {
                if (!string.IsNullOrEmpty(categoryName))
                {
                    if (DoesNodenameExicst(categoryName, categoryListDocType.Id))
                    {
                        DocumentType dt = GetDocumentTypeByName("CategoryDocType");
                        if (dt != null)
                        {
                            try
                            {
                                Document newCategoryDoc = Document.MakeNew(
                                    categoryName.Trim(),
                                    dt, User.GetCurrent(),
                                    GetCategoryListNode().Id);
                                newCategoryDoc.Publish(User.GetCurrent());
                                umbraco.library.UpdateDocumentCache(newCategoryDoc.Id);
                                return "Kategorien " + categoryName + " blev oprettet"; //TODO: Umbraco disc...?
                            }
                            catch (Exception ex)
                            {
                                //TODO: Custom logging...?

                                return ex.Message;

                            }

                        }
                        return "Kunne ikke Kategori dokumenttypen";
                    }
                    return "Der findes allerede en kategori med navnet " + categoryName;
                }
                return "Kategori navn er ikke udfyldt";
            }
            return "Kunne ikke finde Kategori node";
        }

        private DocumentType GetDocumentTypeByName(string documentTypeName)
        {
            if (!string.IsNullOrEmpty(documentTypeName))
            {
                return DocumentType.GetAllAsList().FirstOrDefault(x => x.Alias == documentTypeName);
            }
            return null;
        }

        private bool DoesNodenameExicst(string name, int parrentId)
        {
            return ContentHelper.GetChildren(parrentId).FirstOrDefault(x => x.Name == name) == null;
        }

        public List<CategoryDocType> GetCategories()
        {
            return ContentHelper.GetChildren<CategoryDocType>(SimpleSettingsPageDocType.CategoryFolderId).ToList();
        }

        public List<NominiesDocType> GetNominies(int parentId)
        {
            return ContentHelper.GetChildren<NominiesDocType>(parentId);
        }

        public string CreateMember(string name, string email)
        {
            MembershipCreateStatus status;
            string pass = Guid.NewGuid().ToString().Substring(0, 8);
            try
            {
                MembershipUser newUser = Membership.CreateUser(name, pass, email, "", "", true, out status);
                return newUser != null ? SimpleSettingsPageDocType.NewsletterSignUpMessage : GetErrorMessage(status);
            }
            catch (Exception)
            {
                return "Der gik noget fuldstændig galt!";
            }
        }

        //TODO: Translate to dk
        private static string GetErrorMessage(MembershipCreateStatus status)
        {
            switch (status)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Brugernavnet er allerede taget - Skriv venligst et nyt";

                case MembershipCreateStatus.DuplicateEmail:
                    return "Denne e-mail addresse er allerede taget. Skriv venligst en anden";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "Denne email er ikke korrekt udformet";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "Shit - Der skete";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }

        public static string GetImageUrlFromId(int imageId)
        {
            return new Media(imageId).Text;

        }

        public string CreateArtist(string artistName)
        {
            NominiesListDocType nominiesDocType = GetNominiesListNode();
            if (nominiesDocType != null)
            {
                if (!string.IsNullOrEmpty(artistName))
                {
                    if (DoesNodenameExicst(artistName, nominiesDocType.Id))
                    {
                        DocumentType dt = GetDocumentTypeByName("NominiesDocType");
                        if (dt != null)
                        {
                            try
                            {
                                Document newArtistDoc = Document.MakeNew(
                                    artistName.Trim(),          //Name
                                    dt,                         //Document type
                                    User.GetCurrent(),          //User
                                    nominiesDocType.Id); //Parrent Id (Must be of type NominiesDocType
                                Media m = CreateMediaLibrary(artistName);
                                newArtistDoc.Save();
                                if (m != null)
                                {
                                    newArtistDoc.getProperty("mediaFolderNodeId").Value = m.Id.ToString();
                                }

                                newArtistDoc.Publish(User.GetCurrent());
                                library.UpdateDocumentCache(newArtistDoc.Id);


                                return "Artisten " + newArtistDoc.Text + " blev oprettet"; //TODO: Umbraco disc...?


                            }
                            catch (Exception ex)
                            {
                                //TODO: Custom logging...?

                                return ex.Message;

                            }

                        }
                        return "Kunne ikke Nominerings dokumenttypen";
                    }
                    return "Der findes allerede en nimoneret med navnet " + artistName;
                }
                return "Artist navn er ikke udfyldt";
            }
            return "Kunne ikke finde Artistmappe noden";
        }

        private Media CreateMediaLibrary(string nominieName)
        {
            MediaType mt = MediaType.GetAllAsList().FirstOrDefault(x => x.Alias.ToLower() == "folder");

            Media m = Media.MakeNew(nominieName, mt, User.GetCurrent(), SimpleSettingsPageDocType.MediaArtistFolderId);

            bool result = CreateSubMediasForArtist(SubMediaDictionary(), m);

            if (m != null && result)
            {
                return m;
            }
            return null;
        }

        private bool CreateSubMediasForArtist(List<string> subFolderTypeNameAndArtistName, Media mediaFolder)
        {
            foreach (string folderName in subFolderTypeNameAndArtistName)
            {
                Media m = Media.MakeNew(folderName, MediaType.GetByAlias("Folder"), User.GetCurrent(), mediaFolder.Id);
                if (m == null)
                {
                    return false;
                }
            }
            return true;
        }

        private List<string> SubMediaDictionary()
        {
            List<string> list = new List<string>();
            list.Add("Videoer");
            list.Add("Musik");
            list.Add("Galleri");
            return list;
        }

        public int CreateNews(string name, bool showInMenu, bool publish)
        {
            //http://localhost:56271/umbraco/editContent.aspx?id=1055
            if (!string.IsNullOrEmpty(name))
            {
                if (SimpleSettingsPageDocType.NewsFolderId > 0)
                {
                    User user = User.GetCurrent();
                    Document newNews = Document.MakeNew(name, DocumentType.GetByAlias("TextPageDoctType"),
                                                        user, SimpleSettingsPageDocType.NewsFolderId);
                    newNews.getProperty("umbracoNaviHide").Value = showInMenu ? 1 : 0;

                    if (publish)
                    {
                        newNews.Publish(user);
                        library.UpdateDocumentCache(newNews.Id);
                    }
                    else
                    {
                        newNews.Save();
                    }

                    return newNews.Id;
                }
            }
            return -1;
        }

        public List<Media> BannersForNewsletter()
        {
            return new Media(SimpleSettingsPageDocType.BannersForNewsletter).Children.FirstOrDefault(x => x.Text == "475x145").Children.ToList();
        }

        public string SaveNewsletter(string newsletterItems, DateTime sendDate)
        {
            string[] newsletterArray = newsletterItems.Split('|');

            if (newsletterArray.Length > 0)
            {
                string newsLetterName = "Nyhedsbrev " + DateTime.Now.ToShortDateString();
                DocumentType dt = GetDocumentTypeByName("NewsletterDocType");
                Document newsLetter = Document.MakeNew(newsLetterName, dt, User.GetCurrent(),
                                                       SimpleSettingsPageDocType.NewsletterFolderId);
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
            if (thisType == NewsletterType.News)
            {
                TextPageDoctType news = GetNews(id);

                NewsletterItem nli = new NewsletterItem();

                nli.Headline = news.Headline;
                nli.Content = news.Description;
                nli.Type = GetType(type);
                nli.ImageUrl = news.ImageUpload;
                nli.LinkUrl = "";
                return nli;
            }
            return null;
        }

        public string RenderNewsletter(NewsletterItem newsletterItem)
        {
            if(newsletterItem.Type == NewsletterType.News)
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
            sb.Append("'" + linkUrl+ "'</a>");
            sb.Append("Læs mere her...");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("<tr><td class='spacer' colspan='2'></td></tr>");
            return sb.ToString();
        }
    }
}
