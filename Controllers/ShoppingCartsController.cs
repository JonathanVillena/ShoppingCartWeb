using ShoppingCartWeb.Models;
using ShoppingCartWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartWeb.Repositories;
using System.Linq;
using ShoppingCartWeb.Helpers;
using System;
using Stripe;

namespace ShoppingCartWeb.Controllers
{
    public class ShoppingCartsController : Controller
    {
        int Total;
        // GET: ShoppingCart
        public ActionResult Index()
        {
            var cart = ShoppingCartRepository.GetCart(HttpContext);
            var CartId = SessionHelper.GetShoppingCartId(HttpContext);
            Console.WriteLine("ShoppingCartsController Index - CartId: " + CartId);
            var items = cart.GetCartItems(CartId);
            // Return the view
            return View(items);
        }
        //
        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            Console.WriteLine("ShoppingCartsController AddTocard - AlbumId: " + id.ToString());
            // Retrieve the album from the database
            var albumRepo = new AlbumRepository();
            var album = albumRepo.Get(id);
            if(album != null)
            {
                var cart = ShoppingCartRepository.GetCart(HttpContext);
                cart.AddToCart(album);
            }
            // Go back to the main store page for more shopping
            return RedirectToAction("Index", "Home");
        }
        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            Console.WriteLine("ShoppingCartsController - RemoveFromCart, RecordId: " + id);
            var cart = ShoppingCartRepository.GetCart(HttpContext);
            return Json(cart.RemoveFromCart(id));
        }
        //
        // GET: /ShoppingCart/CartSummary
        public ActionResult CartSummary()
        {
            var cart = ShoppingCartRepository.GetCart(this.HttpContext);
            ViewData["CartCount"] = cart.GetCount();
            Total = cart.GetCount() ;
            return PartialView("CartSummary");
        }
        [HttpPost]
        public ActionResult Payment(string stripeEmail, string stripeToken)
        {
            var customers = new StripeCustomerService();
            var charges = new StripeChargeService();
            
            var customer = customers.Create(new StripeCustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken,
               
            });

            var charge = charges.Create(new StripeChargeCreateOptions
            {
                Amount = 500,
                Description = "Sample Charge",
                Currency = "usd",
                CustomerId = customer.Id
            });

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Error()
        {
            return View();
        }

    }
}