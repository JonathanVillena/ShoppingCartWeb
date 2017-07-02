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
using Microsoft.AspNetCore.Authorization;

namespace ShoppingCartWeb.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {          
            CartRepository repositoryCart = new CartRepository();
            Console.WriteLine(repositoryCart.GetAll());
            return View(repositoryCart.GetAll());
        }
        public IActionResult AddToCart(int id)
        {
            CartRepository repositoryCart = new CartRepository();
            Cart b= new Cart();
            b.AlbumId= id;
            repositoryCart.Add(b);

            return RedirectToAction("Index","Home");
        }

        // GET: Carts/Create
        //[Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            //Necesario 
            //ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "Title");
            return View();
        }

    }
}
