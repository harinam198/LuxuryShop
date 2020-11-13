using luxuryShop.Models.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace luxuryShop.Views.ViewModels
{
    public class OrderDetailsViewModel
    {
        public List<ProductDetail> orderDetails { get; set; }
    }
}