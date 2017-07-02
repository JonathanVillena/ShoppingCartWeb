using ShoppingCartWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ShoppingCartWeb.Helpers;
using ShoppingCartWeb.ViewModels;
using ShoppingCartWeb.Network;
using Newtonsoft.Json;

namespace ShoppingCartWeb.Repositories
{
    public class ShoppingCartRepository
    {
        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        public static ShoppingCartRepository GetCart(HttpContext context)
        {
            var cart = new ShoppingCartRepository();
            cart.ShoppingCartId = SessionHelper.GetShoppingCartId(context);
            return cart;
        }
        // Helper method to simplify shopping cart calls
        public static ShoppingCartRepository GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        public void AddToCart(Album album)
        {
            CartViewModel cart = new CartViewModel
            {
                AlbumId = album.AlbumId,
                GenreId = album.GenreId,
                ArtistId = album.ArtistId,
                Title = album.Title,
                Price = album.Price,
                CartId = ShoppingCartId
            };
            var response = RequestHelper.Post(ShoppingCartAPI.AddToCartURL, cart);
            Console.WriteLine("AddToCart response: " + response);
        }
        public ShoppingCartRemoveViewModel RemoveFromCart(int id)
        {
            CartDeleteViewModel cart = new CartDeleteViewModel
            {
                ShoppingCartId = this.ShoppingCartId,
                RecordId = id
            };
            var result = RequestHelper.Post(ShoppingCartAPI.RemoveFromCartURL, cart);
            return JsonConvert.DeserializeObject<ShoppingCartRemoveViewModel>(result);
        }

        public int GetCount()
        {
            var url = ShoppingCartAPI.ShoppingCartURL + "/?ShoppingCartId=" + this.ShoppingCartId;
            var result = RequestHelper.Get(url);
            return Int32.Parse(result);
        }
        public void EmptyCart()
        {
            /* 
            var cartItems = storeDB.Carts.Where(
                cart => cart.CartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                storeDB.Carts.Remove(cartItem);
            }
            // Save changes
            storeDB.SaveChanges();
            */
        }
        public ShoppingCartViewModel GetCartItems(string ShoppingCartId)
        {
            var response = RequestHelper.Get(ShoppingCartAPI.ShoppingCartURL + "/" + ShoppingCartId);
            Console.WriteLine("GetCartItems result: " + response);
            return JsonConvert.DeserializeObject<ShoppingCartViewModel>(response);
        }

        public Order CreateOrder(Order order)
        {
            var URL = ShoppingCartAPI.AddressAndPaymentURL;
            var orderVM = new OrderViewModel
            {
                order = order,
                shoppingCartId = this.ShoppingCartId,
                promoCode = ""
            };
            var response = RequestHelper.Post(URL, orderVM);
            try
            {
                Console.WriteLine("Create order result: " + response);
                return JsonConvert.DeserializeObject<Order>(response);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error on create order, error message: " + ex.Message);
                return null;
            }
        }
        public int CreateOrder(Order order, String PromoCode)
        {
            return 0;
        }
        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string currentCartId, string userName)
        {
            var model = new MigrateCardViewModel
            {
                OldCartId = currentCartId,
                CartId = userName
            };
            var response = RequestHelper.Post(ShoppingCartAPI.MigrateCartURL, model);
            Console.WriteLine("Migrate result: " + response);
        }
    }
}
