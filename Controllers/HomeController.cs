using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS4200Hackett.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Patrick Hackett's Description/About Patrick Hackett";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact information for Patrick Hackett";

            return View();
        }
    }
}