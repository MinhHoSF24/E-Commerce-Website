using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext dbConnect = new ApplicationDbContext();
        // GET: Admin/Category
        public ActionResult Index()
        {
            var items = dbConnect.Categories;
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Category model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
                dbConnect.Categories.Add(model);
                dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var item = dbConnect.Categories.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                dbConnect.Categories.Attach(model);
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
                dbConnect.Entry(model).Property(x => x.Title).IsModified = true;
                dbConnect.Entry(model).Property(x => x.Description).IsModified = true;
                dbConnect.Entry(model).Property(x => x.Alias).IsModified = true;
                dbConnect.Entry(model).Property(x => x.SellDescription).IsModified = true;
                dbConnect.Entry(model).Property(x => x.SellKeyWords).IsModified = true;
                dbConnect.Entry(model).Property(x => x.SellTitle).IsModified = true;
                dbConnect.Entry(model).Property(x => x.Position).IsModified = true;
                dbConnect.Entry(model).Property(x => x.ModifiedBy).IsModified = true;
                dbConnect.Entry(model).Property(x => x.ModifiedDate).IsModified = true;
                dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var check = dbConnect.Categories.Find(id);
            if (check != null)
            {
                dbConnect.Categories.Remove(check);
                dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}