using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySanPham.Controllers
{
      public class PartialController : Controller
    {
        QuanLySanPhamEntities2 context = new QuanLySanPhamEntities2();
        // GET: Partial
        public ActionResult Index()
        {
            return View();
        }
         public ActionResult DanhSachDanhMuc()
        {
            return View(context.Catalogs.ToList());
        }
        public ActionResult DanhSachSanPham(int iddm)
        {
            var dsSp = context.Products.Where(x => x.CalogId == iddm).ToList();
            return PartialView("DanhSachSanPham",dsSp);
        }
    }

}