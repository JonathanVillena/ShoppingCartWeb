using System;
using ShoppingCartWeb.Models;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using ShoppingCartWeb.Helpers;
using ShoppingCartWeb.Network;

namespace ShoppingCartWeb.Repositories
{
    public class GenreRepository : IDataAccess<Genre, int>
    {
        public void Add(Genre b)
        {
            try
            {
                var result = RequestHelper.Post(ShoppingCartAPI.GenreURL, b);
                Console.WriteLine("Genre post result: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en post Genre: " + ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var result = RequestHelper.Delete(ShoppingCartAPI.GenreURL + "/" + id.ToString());
                Console.WriteLine("Genre delete result: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en delete Genre: " + ex.Message);
            }
        }

        public Genre Get(int id)
        {
            try
            {
                var result = RequestHelper.Get(ShoppingCartAPI.GenreURL + "/" + id.ToString());
                return JsonConvert.DeserializeObject<Genre>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en get Genre: " + ex.Message);
                return null;
            }
        }

        public IEnumerable<Genre> GetAll()
        {
            try
            {
                var result = RequestHelper.Get(ShoppingCartAPI.GenreURL);
                return JsonConvert.DeserializeObject<IEnumerable<Genre>>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en get Genres: " + ex.Message);
                return new List<Genre>();
            }
        }

        public void Update(Genre b)
        {
            try
            {
                string url = ShoppingCartAPI.GenreURL + "/" + b.GenreId.ToString();
                var result = RequestHelper.Put(url, b);
                Console.WriteLine("Genre update result: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en update Genre: " + ex.Message);
            }
        }
    }
}