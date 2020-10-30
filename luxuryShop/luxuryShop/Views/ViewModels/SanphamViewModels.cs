using luxuryShop.Models.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace luxuryShop.Views.ViewModels
{
    public class SanphamViewModels
    {
        public List<Product> sanphams { get; set; }
        public int pageSize { get; set; }
        public int pageIndex { get; set; }
        public int TotalRecord { get; set; }
        public int TotalPage { get; set; }
    }
}