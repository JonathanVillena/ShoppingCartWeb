using System;
using ShoppingCartWeb.Models;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using ShoppingCartWeb.Helpers;
using ShoppingCartWeb.Network;

namespace ShoppingCartWeb.Repositories
{
    public class ArtistRepository : IDataAccess<Artist, int>
    {
        public void Add(Artist b)
        {
            try
            {
                var result = RequestHelper.Post(ShoppingCartAPI.ArtistURL, b);
                Console.WriteLine("Artist post result: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en post Artist: " + ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var result = RequestHelper.Delete(ShoppingCartAPI.ArtistURL + "/" + id.ToString());
                Console.WriteLine("Artist delete result: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en delete Artist: " + ex.Message);
            }
        }

        public Artist Get(int id)
        {
            try
            {
                var result = RequestHelper.Get(ShoppingCartAPI.ArtistURL + "/" + id.ToString());
                return JsonConvert.DeserializeObject<Artist>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en get Artist: " + ex.Message);
                return null;
            }
        }

        public IEnumerable<Artist> GetAll()
        {
            try
            {
                var result = RequestHelper.Get(ShoppingCartAPI.ArtistURL);
                return JsonConvert.DeserializeObject<IEnumerable<Artist>>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en get Artists: " + ex.Message);
                return new List<Artist>();
            }
        }

        public void Update(Artist b)
        {
            try
            {
                string url = ShoppingCartAPI.ArtistURL + "/" + b.ArtistId.ToString();
                var result = RequestHelper.Put(url, b);
                Console.WriteLine("Artist update result: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en update Artist: " + ex.Message);
            }
        }
    }
}