using System;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
namespace ShoppingCartWeb.Helpers
{
    public class SessionHelper
    {
        public static string GetShoppingCartId(HttpContext context)
        {
            var key = context.Session.GetString("CartId");
            if (string.IsNullOrEmpty(key))
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                    key = context.User.Identity.Name;
                else
                    // Generate a new random GUID using System.Guid class
                    key = Guid.NewGuid().ToString();
                // save the cardId  
                SetShoppingCartId(context, key);
            }
            return key;
        }
        public static void SetShoppingCartId(HttpContext context, string shoppingCartId){
            context.Session.SetString("CartId", shoppingCartId);
        }
    }
}