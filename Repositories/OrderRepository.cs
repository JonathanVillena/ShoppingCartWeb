using System;
using ShoppingCartWeb.Models;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using ShoppingCartWeb.Helpers;
using ShoppingCartWeb.Network;

namespace ShoppingCartWeb.Repositories
{
    public class OrderRepository : IDataAccess<Order, int>
    {
        public void Add(Order b)
        {
            try
            {
                var result = RequestHelper.Post(ShoppingCartAPI.OrderURL, b);
                Console.WriteLine("Order post result: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en post Order: " + ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var result = RequestHelper.Delete(ShoppingCartAPI.OrderURL + "/" + id.ToString());
                Console.WriteLine("Order delete result: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en delete Order: " + ex.Message);
            }
        }

        public Order Get(int id)
        {
            try
            {
                var result = RequestHelper.Get(ShoppingCartAPI.OrderURL + "/" + id.ToString());
                return JsonConvert.DeserializeObject<Order>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en get Order: " + ex.Message);
                return null;
            }
        }

        public IEnumerable<Order> GetAll()
        {
            try
            {
                var result = RequestHelper.Get(ShoppingCartAPI.OrderURL);
                return JsonConvert.DeserializeObject<IEnumerable<Order>>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en get Order: " + ex.Message);
                return new List<Order>();
            }
        }

        public IEnumerable<Order> GetAll(string ShoppingCartId)
        {
            try
            {
                var result = RequestHelper.Get(ShoppingCartAPI.OrderURL + "/" + ShoppingCartId);
                return JsonConvert.DeserializeObject<IEnumerable<Order>>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en get Order: " + ex.Message);
                return new List<Order>();
            }
        }

        public IEnumerable<OrderDetail> GetDetails(int id)
        {

            try
            {
                var result = RequestHelper.Get(ShoppingCartAPI.OrderURL + "/Details/" + id);
                return JsonConvert.DeserializeObject<IEnumerable<OrderDetail>>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en get Order: " + ex.Message);
                return new List<OrderDetail>();
            }
        }

        public void Update(Order b)
        {
            try
            {
                string url = ShoppingCartAPI.OrderURL + "/" + b.OrderId.ToString();
                var result = RequestHelper.Put(url, b);
                Console.WriteLine("Order update result: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en update Order: " + ex.Message);
            }
        }
    }
}