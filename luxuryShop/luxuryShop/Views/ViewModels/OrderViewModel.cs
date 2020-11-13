using luxuryShop.Models.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace luxuryShop.Views.ViewModels
{
    public class OrderViewModel
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public List<Cart> orders { get; set; }
        public int pageSize { get; set; }
        public int pageIndex { get; set; }
        public int TotalRecord { get; set; }
        public int TotalPage { get; set; }
    }
}