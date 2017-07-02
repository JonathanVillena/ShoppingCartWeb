using ShoppingCartWeb.Helpers;
using ShoppingCartWeb.Network;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System;
using System.Net.Http.Headers;

namespace ShoppingCartWeb.Helpers
{
    public class RequestHelper
    {
        public static string Get(string URL)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", TokenManager.RequestToken());
            var response = httpClient.GetAsync(URL).Result;

            return response.Content.ReadAsStringAsync().Result;
        }
        public static string Post(string URL, object model)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", TokenManager.RequestToken());
            var serializable = serializeModel(model);
            var response = httpClient.PostAsync(URL, serializable).Result;
            return response.Content.ReadAsStringAsync().Result;
        }
        public static string Delete(string URL){
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", TokenManager.RequestToken());
            var response = httpClient.DeleteAsync(URL).Result;
            return response.Content.ReadAsStringAsync().Result;
        }
        public static string Put(string URL, object model){
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", TokenManager.RequestToken());
            var serializable = serializeModel(model);
            var response = httpClient.PutAsync(URL, serializable).Result;
            return response.Content.ReadAsStringAsync().Result;
        }
        public static ByteArrayContent serializeModel(object model){
            var serializable = JsonConvert.SerializeObject(model);
            var buffer = System.Text.Encoding.UTF8.GetBytes(serializable);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return byteContent;
        }
    }
}