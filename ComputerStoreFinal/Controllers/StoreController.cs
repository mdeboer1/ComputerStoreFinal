using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerStoreFinal.Models;
using ComputerStoreFinal.DataContexts;

namespace ComputerStoreFinal.Controllers
{
    public class StoreController : Controller
    {
        ComputerStoreDb ComputerStoreDb = new ComputerStoreDb();
        // GET: Store
        public ActionResult Index()
        {
            var category = ComputerStoreDb.Categories.ToList<Category>();
            var parts = ComputerStoreDb.Parts.ToList<Part>();
            ViewBag.parts = parts;
            return View(category);
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            int count = 0;
            foreach(var data in Request.Form)
            {
                TempData[count.ToString()] = data;
                count++;
            }
            return RedirectToAction("AddToCart", "ShoppingCart");
        }

        public ActionResult Prebuilt()
        {
            var computers = ComputerStoreDb.Computers.ToList<Computer>();

            return View();
        }

        public ActionResult Browse()
        {

            return View();
        }

        public ActionResult Details(int id)
        {
            var part = ComputerStoreDb.Parts.Find(id);
            return View(part);
        }
    }
}