using NewsPaperProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NewsPaperProject.Controllers
{
    public class NewsPostController : Controller
    {
        // GET: NewsPost
        basicEntities db = new basicEntities();
        public ActionResult AddPost()
        {
            tbl_news cat = new tbl_news();
            cat.categorylist
                = db.categories
                     .Select(o => new SelectListItem { Value = o.categoryid.ToString(), Text = o.categoryname })
                     .ToList();

            //cat.categorylist = db.categories.ToList<category>();
            return View(cat);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddPost(tbl_news n)
        {
           
               
                //n.categoryid = n.categoryid;
                //n.categorylist = n.categorylist;
                //n.categoryid = n.categoryid;
                n.short_headline = n.short_headline;
                n.headline = n.headline;
                n.desc = n.desc;
                n.ImageTitle = n.ImageTitle;
                n.Alttext = n.Alttext;
                string fileName = Path.GetFileNameWithoutExtension(n.ImageFile.FileName);
                string extension = Path.GetExtension(n.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                n.ImagePath = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                n.ImageFile.SaveAs(fileName);


            db.tbl_news.Add(n);
            db.SaveChanges();
            ModelState.Clear();
            return View(n);
        }
           
        
        
        public ActionResult NewsList()
        {
            return View(db.tbl_news.ToList());
        }
        public ActionResult Delete(int? id)
        {
            if( id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var n = db.tbl_news.Find(id);
            if(n == null)
            {
                return HttpNotFound();
            }
            db.Entry(n).State = System.Data.Entity.EntityState.Deleted;
            return View();
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_news Nav = db.tbl_news.Find(id);
            db.tbl_news.Remove(Nav);
            db.SaveChanges();
            return RedirectToAction("NewsList");
        }
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var n = db.tbl_news.Find(id);
            if(n == null)
            {
                return HttpNotFound();
            }
            return View(n);
        }
    }
}