using ShoppingCartWeb.Models;
using ShoppingCartWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartWeb.Repositories;
using System.Linq;
using ShoppingCartWeb.Helpers;
using System;

namespace ShoppingCartWeb.Controllers
{
    public class OrdersController : Controller
    {
        private OrderRepository orders = new OrderRepository();
        public ActionResult Index()
        {
            return View(orders.GetAll(SessionHelper.GetShoppingCartId(HttpContext)));
        }

        [HttpGet("Details/{id}")]
        public ActionResult Details(int id)
        {
            return View(orders.GetDetails(id));
        }
    }
}