﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InnerSoft.MeEncontre.Web.Site.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var rota = "/DashBoard";
            return Redirect(rota);

            ViewBag.Message = "Modify this template to kick-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
