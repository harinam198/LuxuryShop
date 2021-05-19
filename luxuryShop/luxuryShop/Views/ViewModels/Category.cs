using luxuryShop.Models.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace luxuryShop.Views.ViewModels
{
    public class Category
    {
        luxuryEntities db = null;
        public Category()
        {
            db = new luxuryEntities();
        }
        public List<Product> Dienthoai(int top)
        {
            return db.Products.Where(x => x.Category == 0).Take(top).ToList();
        }
        public List<Product> Tainghe()
        {
            return db.Products.Where(x => x.Category == 1).OrderByDescending(x => x.ID).ToList();
        }
        public List<Product> Dongho()
        {
            return db.Products.Where(x => x.Category == 2).OrderByDescending(x => x.ID).ToList();
        }
        public List<Product> BestSeller()
        {
            return db.Products.Where(x => x.BestSeller != null).OrderByDescending(x => x.ID).ToList();
        }
    }
}