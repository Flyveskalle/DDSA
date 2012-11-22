using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return ContentHelper.GetChildren<TextPageDoctType>(SimpleSettingsPageDocType.NewsFolderId).Where(x => x.Template == DocumentType.GetByAlias("News").Id).OrderByDescending(x => x.CreateDate).ToList();
        }

        public CategoryListDocType GetCategoryListNode()
        {
            return ContentHelper.GetByNodeId <CategoryListDocType>(SimpleSettingsPageDocType.CategoryFolderId);
        }

        public NominiesListDocType GetNominiesListNode()
        {
            return ContentHelper.GetChildren(SimpleSettingsPageDocType.Homepage).Where(x => x is NominiesListDocType).FirstOrDefault() as NominiesListDocType;
        }

        public string CreateCategory(string categoryName)
        {
            //Locate Category node in umbraco tree
                CategoryListDocType categoryListDocType = new DualShockManager().GetCategoryListNode();
                if(categoryListDocType != null)
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
            if(!string.IsNullOrEmpty(documentTypeName))
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
                                if(m != null)
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

            bool result  = CreateSubMediasForArtist(SubMediaDictionary(), m);

            if( m != null && result)
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
                if(m == null)
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
            if(!string.IsNullOrEmpty(name))
            {
                if(SimpleSettingsPageDocType.NewsFolderId > 0)
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

        

    }
}
