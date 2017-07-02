using System;
using ShoppingCartWeb.Models;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using ShoppingCartWeb.Helpers;
using ShoppingCartWeb.Network;

namespace ShoppingCartWeb.Repositories
{
    public class OrderDetailRepository : IDataAccess<OrderDetail, int>
    {
        public void Add(OrderDetail b)
        {
            try
            {
                var result = RequestHelper.Post(ShoppingCartAPI.OrderDetailURL, b);
                Console.WriteLine("OrderDetail post result: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en post OrderDetail: " + ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var result = RequestHelper.Delete(ShoppingCartAPI.OrderDetailURL + "/" + id.ToString());
                Console.WriteLine("OrderDetail delete result: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en delete OrderDetail: " + ex.Message);
            }
        }

        public OrderDetail Get(int id)
        {
            try
            {
                var result = RequestHelper.Get(ShoppingCartAPI.OrderDetailURL + "/" + id.ToString());
                return JsonConvert.DeserializeObject<OrderDetail>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en get OrderDetail: " + ex.Message);
                return null;
            }
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            try
            {
                var result = RequestHelper.Get(ShoppingCartAPI.OrderDetailURL);
                return JsonConvert.DeserializeObject<IEnumerable<OrderDetail>>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en get OrderDetail: " + ex.Message);
                return new List<OrderDetail>();
            }
        }

        public void Update(OrderDetail b)
        {
            try
            {
                string url = ShoppingCartAPI.OrderDetailURL + "/" + b.OrderDetailId.ToString();
                var result = RequestHelper.Put(url, b);
                Console.WriteLine("OrderDetail update result: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en update OrderDetail: " + ex.Message);
            }
        }
    }
}