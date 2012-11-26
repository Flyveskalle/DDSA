using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDSA.Backend.Business.DataObjects
{
    public class NewsletterItem
    {
        public string Headline { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public NewsletterType Type { get; set; }
        public string LinkUrl { get; set; }
    }
}
