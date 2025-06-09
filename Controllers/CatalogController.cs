using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySanPham.Controllers
{
    public class CatalogController : Controller
    {
        // GET: Catalog
        public ActionResult Index()
        {
            var context = new QuanLySanPhamEntities2();
            //context.Catalogs.Add(new Catalog()
            //{
            //    CatalogCode = "Giang",
            //    CatalogName = "GIANGGG"
            //});
            //context.SaveChanges();
            var list = context.Catalogs.ToList();
            ViewData.Model = list;
            return View();
        }
        public ActionResult Details(int Id)
        {
            QuanLySanPhamEntities2 context = new QuanLySanPhamEntities2();
            Catalog cate = context.Catalogs.FirstOrDefault(c => c.Id == Id);
            ViewData.Model = cate;
            return View();
        }
        public ActionResult SanPhams(int id)
        {
            QuanLySanPhamEntities2 context = new QuanLySanPhamEntities2();
            List<Product> products = context.Products.Where(x => x.CalogId == id).ToList();
            ViewData.Model = products;
            return View();
        }

        public ActionResult Create()
        {
            string catalogCode = Request.Form["Catalogcode"];
            string catalogName = Request.Form["CatalogName"];

            QuanLySanPhamEntities2 context = new QuanLySanPhamEntities2();
            Catalog catalog = new Catalog();
            catalog.CatalogCode = catalogCode;
            catalog.CatalogName = catalogName;
            context.Catalogs.Add(catalog);
            context.SaveChanges();
            ViewData.Model = catalog;
            return View();
        }

        public ActionResult Delete(int id)
        {
            QuanLySanPhamEntities2 context = new QuanLySanPhamEntities2();
            Catalog catalog = context.Catalogs.FirstOrDefault(x => x.Id == id);

            if(catalog != null)
            {
                context.Catalogs.Remove(catalog);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            QuanLySanPhamEntities2 context = new QuanLySanPhamEntities2();
            Catalog catalog = context.Catalogs.FirstOrDefault(x => x.Id == id);

            if(Request.Form.Count == 0)
            {
                //
                return View(catalog);
            } 
            
            string catalogCode = Request.Form["CatalogCode"];
            string catalogName = Request.Form["CatalogName"];

            if (catalogCode.Length == 0)
            {
                ModelState.AddModelError("CatalogCode", "Không được để trống");

            }
            if (catalogName.Length == 0)
            {
                ModelState.AddModelError("CatalogName", "Không được để trống");

            }
            //if (!ModelState.IsValid)
            //{
            //    catalog.CatalogCode = catalogCode;
            //    catalog.CatalogName = catalogName;
            //    return View(catalog);
            //}

            catalog.CatalogCode = catalogCode;
            catalog.CatalogName = catalogName;

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult PartialCatalog()
        {
            QuanLySanPhamEntities2 context = new QuanLySanPhamEntities2();
            var dmDs = context.Catalogs.ToList();
            return PartialView("PartialCatalog", dmDs);
        }
    }
}