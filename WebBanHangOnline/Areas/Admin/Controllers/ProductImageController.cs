using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class ProductImageController : Controller
    {
        ApplicationDbContext dbConnect = new ApplicationDbContext();
        // GET: Admin/ProductImage
        public ActionResult Index(int id)
        {
            ViewBag.ProductId = id;
            var item = dbConnect.ProductImages.Where(x => x.ProductId == id).ToList();
            return View(item);
        }
        [HttpPost]
        public ActionResult AddImage(int productId, string url)
        {
            dbConnect.ProductImages.Add(new Models.EF.ProductImage
            {
                ProductId = productId,
                Image = url,
                IsDefault = false
            });
            dbConnect.SaveChanges();
            return Json(new { Success = true });
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = dbConnect.ProductImages.Find(id);
            dbConnect.ProductImages.Remove(item);
            dbConnect.SaveChanges();
            return Json(new { success = true });
        }
    }
}