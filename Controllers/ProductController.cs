using QuanLySanPham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySanPham.Controllers
{
    public class ProductController : Controller
    {
        public ProductController()
        {

        }
        // GET: Product
        public ActionResult Index()
        {
            var context = new QuanLySanPhamEntities2();
            List<ProductViewModel> list = new List<ProductViewModel>();


            if (Request.QueryString.Count == 0)
            {
                list = context.Products//.Where(c => c.Id > 3)
                    .Select(c => new ProductViewModel()
                    {
                        Id= c.Id,
                        Catalog = c.Catalog,
                        Code = c.ProductCode,
                        Name = c.ProductName,
                        Unitprice = (double)c.UnitPrice
                    })
                    .ToList();
            }
            else
            {
                double min = double.Parse(Request.QueryString["txtMin"]);
                double max = double.Parse(Request.QueryString["txtMax"]);

               list = context.Products
                    .Where(x => x.UnitPrice >= min && x.UnitPrice <= max)
                    .Select(c => new ProductViewModel()
                    {
                        Id = c.Id,
                        Catalog = c.Catalog,
                        Code = c.ProductCode,
                        Name = c.ProductName,
                        Unitprice = (double)c.UnitPrice
                    }).ToList();

            }

            ViewData.Model = list;
            return View("Product");
        }
        [HttpGet]
        public ActionResult Create()
        {
            var context = new QuanLySanPhamEntities2();
            ViewBag.Catalog = context.Catalogs.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(QuanLySanPham.Product model)
        {

            
            var context = new QuanLySanPhamEntities2();
            //Vi du insert du lieu
            var product = new Product();
            product.CalogId = model.CalogId;
            product.ProductCode = model.ProductCode;
            product.ProductName = model.ProductName;
            product.UnitPrice = model.UnitPrice;

            context.Products.Add(product);
            context.SaveChanges();
            return Redirect("Index");
        }

        public ActionResult Detail(int Id)
        {
            var context = new QuanLySanPhamEntities2();
            Product product = context.Products.FirstOrDefault(x => x.Id == Id);
            return View();
        }

        public ActionResult SapXepTheoDonGiaVaTen()
        {
            QuanLySanPhamEntities2 context = new QuanLySanPhamEntities2();
            List<Product> products = context.Products.OrderBy(x => x.UnitPrice).OrderByDescending(x => x.ProductName).ToList();
            return View("Product");
        }

        public ActionResult PartialProduct()
        {
            
            var context = new QuanLySanPhamEntities2();
            var dsSp = context.Products.ToList();
            ViewData.Model = dsSp;
            return PartialView("PartialProduct");
        }
        public ActionResult Delete(int id)
        {
            QuanLySanPhamEntities2 context = new QuanLySanPhamEntities2();
            var product = context.Products.FirstOrDefault(x => x.Id == id);
            if(product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
                
            }
            return RedirectToAction("Index");
        }


    }
}