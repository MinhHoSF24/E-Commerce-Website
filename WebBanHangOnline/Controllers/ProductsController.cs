using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext dbConnect = new ApplicationDbContext();
        // GET: Products
        public ActionResult Index(int? id)
        {
            var items = dbConnect.Products.ToList();
            if (id != null)
            {
                items = items.Where(x=>x.ProductCategoryId == id).ToList();
            }
            return View(items);
        }
        public ActionResult ProductCategory(string alias, int? id)
        {
            var items = dbConnect.Products.ToList();
            if (id > 0)
            {
                items = items.Where(x => x.ProductCategoryId == id).ToList();
            }
            var cate = dbConnect.ProductCategories.Find(id);
            if (cate != null)
            {
                ViewBag.CateName = cate.Title;
            }
            ViewBag.CateId = id;
            return View(items);
        }

        public ActionResult Detail(string alias,int? id)
        {
            var item  = dbConnect.Products.Find(id);
            return View(item);
        }

        public ActionResult Partial_ItemsByCateId()
        {
            var item = dbConnect.Products.Where(x=>x.IsHome && x.IsActive).Take(12).ToList();
            return PartialView(item);
        }
        
        public ActionResult Partial_ProductSale()
        {
            var item = dbConnect.Products.Where(x=>x.IsSale).ToList();
            return PartialView(item);
        }
    }
}