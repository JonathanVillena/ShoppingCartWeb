using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartWeb.Models;
using ShoppingCartWeb.Repositories;
using System.Net.Http;
using Newtonsoft.Json;

namespace ShoppingCartWeb.Controllers
{
    public class AlbumController : Controller
    {
        public IActionResult MostrarDetalle(int id)
        {
            var albumRepo = new AlbumRepository();
            Album album = albumRepo.Get(id);                
            return View(album);
        }

    }
}
