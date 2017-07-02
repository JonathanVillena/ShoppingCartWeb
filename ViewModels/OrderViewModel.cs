using ShoppingCartWeb.Models;

namespace ShoppingCartWeb.ViewModels
{
    public class OrderViewModel
    {
        public Order order { get; set; }
        public string shoppingCartId { get; set;}
        public string promoCode { get; set;}
    }
}