using System;
using System.Collections.Generic;
using ShoppingCartWeb.Models;

namespace ShoppingCartWeb.ViewModels
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
    public class ShoppingCartRemoveViewModel
    {
        public string Message { get; set; }
        public decimal CartTotal { get; set; }
        public int CartCount { get; set; }
        public int ItemCount { get; set; }
        public int DeleteId { get; set; }
    }
}