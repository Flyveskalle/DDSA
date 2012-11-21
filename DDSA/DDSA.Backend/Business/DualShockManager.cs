using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDSA.Backend.Business.DocTypes;
using Vega.USiteBuilder;
//using uComponents.Core;
//using uComponents.DataTypes;
using umbraco;
using umbraco.businesslogic;
using umbraco.cms.businesslogic.web;
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
                    foreach (DocumentTypeBase child in ContentHelper.GetChildren(uQuery.GetRootNode().Id, false))
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
            return ContentHelper.GetChildren<TextPageDoctType>(SimpleSettingsPageDocType.NewsFolderId).Where(x => x.Template == DocumentType.GetByAlias("News").Id).OrderByDescending(x => x.CreateDate).ToList();
        }

    }
}
