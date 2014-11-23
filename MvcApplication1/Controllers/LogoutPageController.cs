﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcApplication1.Controllers
{
    public class LogoutPageController : Controller
    {
        //
        // GET: /LogoutPage/

        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            return View();
        }

    }
}
