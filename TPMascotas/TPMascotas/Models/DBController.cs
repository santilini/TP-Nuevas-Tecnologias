﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPMascotas.Models
{
    public class DBController : Controller
    {
        // GET: DB
        public ActionResult Index()
        {
            return View();
        }
    }
}