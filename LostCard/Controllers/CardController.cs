﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LostCard.Models;
using System.Net.Http;

namespace LostCard.Controllers
{
    public class CardController : Controller
    {
        // GET: Card
        public ActionResult Index()
        {
            IEnumerable<mvcCards> myList = null;
            HttpResponseMessage response = GlobalVariables.webApi.GetAsync("Cards").Result;
            myList = response.Content.ReadAsAsync<IEnumerable<mvcCards>>().Result;
            return View();
        }
    }
}