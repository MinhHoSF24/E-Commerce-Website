using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Controllers
{
    public class MenuController : Controller
    {
        private ApplicationDbContext dbConnect = new ApplicationDbContext();
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MenuTop()
        {
            var item = dbConnect.Categories.OrderBy(x => x.Position).ToList();
            return PartialView("_MenuTop",item);
        }

        public ActionResult MenuProductCategory()
        {
            var items = dbConnect.ProductCategories.ToList();
            return PartialView("_MenuProductCategory", items);
        }
        public ActionResult MenuLeft(int? id)
        {
            if(id != null)
            {
                ViewBag.CateId = id;
            }
            var items = dbConnect.ProductCategories.ToList();
            return PartialView("_MenuLeft", items);
        }
        public ActionResult MenuArrivals()
        {
            var item = dbConnect.ProductCategories.ToList();
            return PartialView("_MenuArrivals", item);
        }
    }
}