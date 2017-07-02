using System;
using ShoppingCartWeb.Models;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using ShoppingCartWeb.Helpers;
using ShoppingCartWeb.Network;

namespace ShoppingCartWeb.Repositories
{
    public class CartRepository : IDataAccess<Cart, int>
    {
        public void Add(Cart b)
        {
            try
            {
                var result = RequestHelper.Post(ShoppingCartAPI.CartURL, b);
                Console.WriteLine("Cart post result: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en post Cart: " + ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var result = RequestHelper.Delete(ShoppingCartAPI.CartURL + "/" + id.ToString());
                Console.WriteLine("Cart delete result: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en delete Cart: " + ex.Message);
            }
        }

        public Cart Get(int id)
        {
            try
            {
                var result = RequestHelper.Get(ShoppingCartAPI.CartURL + "/" + id.ToString());
                return JsonConvert.DeserializeObject<Cart>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en get Cart: " + ex.Message);
                return null;
            }
        }

        public IEnumerable<Cart> GetAll()
        {
            try
            {
                var result = RequestHelper.Get(ShoppingCartAPI.CartURL);
                return JsonConvert.DeserializeObject<IEnumerable<Cart>>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en get Carts: " + ex.Message);
                return new List<Cart>();
            }
        }

        public void Update(Cart b)
        {
            try
            {
                string url = ShoppingCartAPI.CartURL + "/" + b.CartId.ToString();
                var result = RequestHelper.Put(url, b);
                Console.WriteLine("Cart update result: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en update Cart: " + ex.Message);
            }
        }
    }
}