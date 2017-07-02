using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartWeb.Models;
using ShoppingCartWeb.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Owin;
using ShoppingCartWeb.Extensions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingCartWeb.Helpers;

namespace ShoppingCartWeb.Controllers
{

    [Authorize]
    public class CheckoutController : Controller
    {
        const string PromoCode = "FREE";
        private readonly UserManager<ApplicationUser> _userManager;
        public CheckoutController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult> AddressAndPayment()
        {
            Console.WriteLine("AddresPaymet - New Order");
            var user = await _userManager.GetUserAsync(HttpContext.User);
            // check to migrate
            CheckCartId(user.UserName);
            Order order = new Order();
            if (user != null)
            {
                order.Email = user.Email;
                order.Username = user.UserName;
                order.Phone = user.PhoneNumber;
            }
            return View(order);
        }

        [HttpPost]
        public ActionResult AddressAndPayment(Order orderVM)
        {
            Console.WriteLine("AddresPaymet - Checking model state");
            if (ModelState.IsValid)
            {
                var cart = ShoppingCartRepository.GetCart(HttpContext);
                var order = cart.CreateOrder(orderVM);

                if (order != null)
                {
                    Console.WriteLine("AddresPaymet - Created with OrderId: " + order.OrderId);
                    return RedirectToAction("Complete", new { id = order.OrderId });
                }
                else
                {
                    Console.WriteLine("AddresPaymet - Order Rejected, check API logs");
                    return View(orderVM);
                }
            }
            else
            {
                Console.WriteLine("AddresPaymet - Invalid Model");
                return View(orderVM);
            }
        }

        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
            Console.WriteLine("Complete order, OrderId: " + id);
            return View(id);
        }

        private void CheckCartId(string UserName)
        {
            Console.WriteLine("Checking CartId");
            var currentCartId = SessionHelper.GetShoppingCartId(HttpContext);
            if (currentCartId != UserName)
            {
                SessionHelper.SetShoppingCartId(HttpContext, UserName);
                var cart = ShoppingCartRepository.GetCart(HttpContext);
                cart.MigrateCart(currentCartId, UserName);
            }
        }
    }
}