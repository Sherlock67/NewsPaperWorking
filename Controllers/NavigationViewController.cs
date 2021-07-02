using NewsPaperProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsPaperProject.Controllers
{
    public class NavigationViewController : Controller
    {
        basicEntities db = new basicEntities();
        // GET: NavigationView
        public ActionResult Index()
        {
            ViewModel vm = new ViewModel();
            var cat = db.categories.ToList();
            var n = db.tbl_news.ToList();
            vm.allnews = n;
            vm.allcategory = cat;
            return View(vm);
        }
    }
}