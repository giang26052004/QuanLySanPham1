using QuanLySanPham.Models;
using System;
using System.Collections.Generic;
using System.Data.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySanPham.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            QuanLySanPhamEntities2 context = new QuanLySanPhamEntities2();
            List<Product> products = context.Products.Where(x => x.CalogId == 2).ToList();
            ViewBag.Products = products;
            //var cte = new CatelogViewModel();
            //cte.Products = new List<ProductViewModel>();
            //cte.Products.Add(new ProductViewModel());
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}