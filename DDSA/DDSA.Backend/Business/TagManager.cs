using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using umbraco.cms.businesslogic.Tags;
using Vega.USiteBuilder;
using DDSA.Backend.Business.DocTypes;

namespace DDSA.Backend.Business
{
    public class TagManager
    {
        public List<DocumentTypeBase> GetResultsFromTagSearch(string tag)
        {
            if (!string.IsNullOrEmpty(tag))
            {
                List<DocumentTypeBase> results = new List<DocumentTypeBase>();

                List<TextPageDoctType> news = new DualShockManager().GetNews().Where(x => x.Tags.ToLower().Contains(tag)).ToList(); ;
                List<NominiesDocType> artists = new DualShockManager().GetNominies(new DualShockManager().SimpleSettingsPageDocType.NominiesFolderId).Where(x => x.Tags.ToLower().Contains(tag)).ToList();

                results.AddRange(news);
                results.AddRange(artists);

                return results.OrderBy(x => x.CreateDate).ToList();
            }
            return null;
        }
    }
}
