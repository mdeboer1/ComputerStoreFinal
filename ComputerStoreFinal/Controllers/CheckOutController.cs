using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerStoreFinal.DataContexts;
using ComputerStoreFinal.Models;

namespace ComputerStoreFinal.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: CheckOut
        ComputerStoreDb ComputerStoreDb = new ComputerStoreDb();

        public ActionResult AddressAndPayment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                order.UserName = User.Identity.IsAuthenticated ?
                    User.Identity.Name : "Guest";
                order.OrderDate = DateTime.Now;

                //Save order
                ComputerStoreDb.Orders.Add(order);

                ComputerStoreDb.SaveChanges();

                //Process order
                var cart = ShoppingCart.GetCart(this.HttpContext);
                cart.CreateOrder(order);

                return RedirectToAction("Complete", order);
            }
            catch(Exception e)
            {
                // invalid - redisplay with errors
                System.Console.Out.WriteLine(e.GetType().ToString());
                System.Console.Out.WriteLine(e.Message);
                return View(order);
            }
        }
        public ActionResult Complete(Order id)
        {
            return View(id);
        }
    }
}
    
