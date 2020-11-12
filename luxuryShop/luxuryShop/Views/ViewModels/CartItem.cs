using luxuryShop.Models.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace luxuryShop.Views.ViewModels
{
    public class CartItem
    {
        public Product sanpham { get; set; }
        public int Quantity { get; set; }
    }
}