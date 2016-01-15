﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            return View();
        }
        public string Browse(string genere) {
            var message = HttpUtility.HtmlEncode("you are looking for"+genere);
            return message;
        }

        public string Details(int Id) {
            return "in Details() hello id="+Id;
        }
    }
}