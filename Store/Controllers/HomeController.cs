using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Models;


namespace Store.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Bed()
        {
            return View("Bed");
        }

        public ActionResult Sofa()
        {
            return View("Sofa");
        }
        public ActionResult Table()
        {
            return View("Table");
        }
    }
}