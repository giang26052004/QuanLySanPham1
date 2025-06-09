using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLySanPham.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public Catalog Catalog { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public double Unitprice { get; set; }
    }

    public class CatelogViewModel
    {
        public CatelogViewModel()
        {
            Products = new List<ProductViewModel>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}