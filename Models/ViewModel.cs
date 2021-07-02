using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsPaperProject.Models
{
    public class ViewModel
    {
        public IEnumerable<category> allcategory { get; set; }
        public IEnumerable<tbl_news> allnews { get; set;}
        
        
        public int nid { get; set; }
        public string short_headline { get; set; }
        public string headline { get; set; }

        public string desc { get; set; }
        public string ImageTitle { get; set; }
        [DisplayName("Upload Images")]
        public string ImagePath { get; set; }
        public string Alttext { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
        public int categoryid { get; set; }

        public List<SelectListItem> cname { get; set; }
        //public List<SelectListItem> cname { get; set; }
    }
}