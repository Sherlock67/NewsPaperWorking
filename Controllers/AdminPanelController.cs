using NewsPaperProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NewsPaperProject.Controllers
{
    public class AdminPanelController : Controller
    {
        basicEntities db = new basicEntities();
        // GET: AdminPanel
        public ActionResult DashBoard()
        {
            return View();
        }  
        public ActionResult NewCatagoryAdd()
        {
            return View();
        } 
        [HttpPost]
        public ActionResult NewCatagoryAdd(category cat)
        {
            cat.categoryname = cat.categoryname;
            db.categories.Add(cat);
            db.SaveChanges();
            return View();
           // return RedirectToAction("VIewNag");

        }
        public ActionResult VIewNag()
        {
            return View(db.categories.ToList());
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            category nav = db.categories.Find(id);
            if (nav == null)
            {
                return HttpNotFound();
            }
            return View(nav);
        }

        // POST: FiftyTakaData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "categoryid,categoryname")] category Var)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Var).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("VIewNag");
            }
            return View(Var);
        }

       // GET: FiftyTakaData/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            category Nav = db.categories.Find(id);
            if (Nav == null)
            {
                return HttpNotFound();
            }
            return View(Nav);
        }

        // POST: FiftyTakaData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            category Nav = db.categories.Find(id);
            db.categories.Remove(Nav);
            db.SaveChanges();
            return RedirectToAction("VIewNag");
        }
        public ActionResult Search()
        {
            return View("SearchPartial");
        }
        [HttpPost]
        public ActionResult Search(string se)
        {
            return View(db.categories.Where(x => x.categoryname.Contains(se) || se == null).ToList());
        }
        public ActionResult Contact_info(int id = 1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contact_info con = db.contact_info.Find(id);
            if (con == null)
            {
                return HttpNotFound();
            }
            return View(con);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Contact_info([Bind(Include = "id,Content,address,phn_one,phn_two,email,website_link")] contact_info con)
        {
            if (ModelState.IsValid)
            {
                db.Entry(con).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Contact_info");
            }
            return View(con);
        }
        public ActionResult Email_setting(int id = 1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Email_setting email = db.Email_setting.Find(id);
            if (email == null)
            {
                return HttpNotFound();
            }
            return View(email);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Email_setting([Bind(Include = "id,smtp_protocol,smtp_host,smtp_port,smtp_username,smtp_pass,smtp_mailtype,smtp_charset")] Email_setting email)
        {
            if (ModelState.IsValid)
            {
                db.Entry(email).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Email_setting");
            }
            return View(email);
        }
        [HttpGet]
        public ActionResult App_Setting_Edit(int id = 1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var app = db.app_setting.Find(id);
            if (app == null)
            {
                return HttpNotFound();
            }
            return View(app);
        }
        public ActionResult App_Setting_Edit(HttpPostedFileBase ImageFile3, HttpPostedFileBase ImageFile4,HttpPostedFileBase ImageFile, HttpPostedFileBase ImageFile1, HttpPostedFileBase ImageFile2, app_setting app)

        {
            if (ModelState.IsValid)
            {
                if (ImageFile3 != null)
                {


                    string fileName = Path.GetFileNameWithoutExtension(app.ImageFile.FileName);
                    string extension = Path.GetExtension(app.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    app.websitelogopath = "~/Image/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                    app.ImageFile.SaveAs(fileName);


                }
                if (ImageFile1 != null)
                {


                    string fileName = Path.GetFileNameWithoutExtension(app.ImageFile1.FileName);
                    string extension = Path.GetExtension(app.ImageFile1.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    app.footerlogopath = "~/Image/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                    app.ImageFile1.SaveAs(fileName);


                }

                if (ImageFile2 != null)
                {


                    string fileName = Path.GetFileNameWithoutExtension(app.ImageFile2.FileName);
                    string extension = Path.GetExtension(app.ImageFile2.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    app.faviconpath = "~/Image/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                    app.ImageFile2.SaveAs(fileName);


                }
                if (ImageFile3 != null)
                {


                    string fileName = Path.GetFileNameWithoutExtension(app.ImageFile3.FileName);
                    string extension = Path.GetExtension(app.ImageFile3.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    app.applogopath = "~/Image/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                    app.ImageFile3.SaveAs(fileName);


                }

                if (ImageFile4 != null)
                {


                    string fileName = Path.GetFileNameWithoutExtension(app.ImageFile4.FileName);
                    string extension = Path.GetExtension(app.ImageFile4.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    app.mblmenupath = "~/Image/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                    app.ImageFile4.SaveAs(fileName);


                }
                else {
                    app.copyright = app.copyright;
                    app.websitetitle = app.websitetitle;
                    app.webfooter = app.webfooter;
                }
               

                db.Entry(app).State = EntityState.Modified;
                db.SaveChanges();
            }
            return View();

        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }


}
