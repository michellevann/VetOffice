﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VetOffice.WebMVC.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }
    }
}