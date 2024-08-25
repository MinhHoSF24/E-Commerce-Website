using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models.EF;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class PostsController : Controller
    {
        ApplicationDbContext dbConnect = new ApplicationDbContext();
        // GET: Admin/Posts
        public ActionResult Index()
        {
            var list = dbConnect.Posts.ToList();
            return View(list);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Posts model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
               
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
                dbConnect.Posts.Add(model);
                dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var item = dbConnect.Posts.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Posts model)
        {
            if (ModelState.IsValid)
            {
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
                dbConnect.Posts.Attach(model);
                dbConnect.Entry(model).State = System.Data.Entity.EntityState.Modified;
                dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var check = dbConnect.Posts.Find(id);
            if (check != null)
            {
                dbConnect.Posts.Remove(check);
                dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}