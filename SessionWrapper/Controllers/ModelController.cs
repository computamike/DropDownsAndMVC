using SessionWrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionWrapper.Controllers
{
    public class ModelController : Controller
    {
        // GET: Model
        public ActionResult Index()
        {
            Person P = new Person();
            return View(P);
        }
        [HttpPost]
        public ActionResult Index(Person p)
        {
            Session["Person"] = p;
            return RedirectToAction("Retrieve");
        }

        public ActionResult Retrieve()
        {
           var p= Session["Person"];
            return View(p);
        }


    }
}