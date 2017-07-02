using System;
using ShoppingCartWeb.Models;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using ShoppingCartWeb.Helpers;
using ShoppingCartWeb.Network;

namespace ShoppingCartWeb.Repositories
{
    public class AlbumRepository : IDataAccess<Album, int>
    {
        public void Add(Album b)
        {
            try
            {
                var result = RequestHelper.Post(ShoppingCartAPI.AlbumURL, b);
                Console.WriteLine("Album post result: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en post album: " + ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var result = RequestHelper.Delete(ShoppingCartAPI.AlbumURL + "/" + id.ToString());
                Console.WriteLine("Album delete result: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en delete album: " + ex.Message);
            }
        }

        public Album Get(int id)
        {
            try
            {
                var result = RequestHelper.Get(ShoppingCartAPI.AlbumURL + "/" + id.ToString());
                return JsonConvert.DeserializeObject<Album>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en get album: " + ex.Message);
                return null;
            }
        }

        public IEnumerable<Album> GetAll()
        {
            try
            {
                var result = RequestHelper.Get(ShoppingCartAPI.AlbumURL);
                return JsonConvert.DeserializeObject<IEnumerable<Album>>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en get albums: " + ex.Message);
                return new List<Album>();
            }
        }

        public void Update(Album b)
        {
            try
            {
                string url = ShoppingCartAPI.AlbumURL + "/" + b.AlbumId.ToString();
                var result = RequestHelper.Put(url, b);
                Console.WriteLine("Album update result: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en update album: " + ex.Message);
            }
        }
    }
}