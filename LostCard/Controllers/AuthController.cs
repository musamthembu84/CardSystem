using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LostCard.Models;

namespace LostCard.Controllers
{
    public class AuthController : Controller
    {
        private LostCardsEntities db = new LostCardsEntities();
        
        private IQueryable<Card> GetCards()
        {
            return null;
        }
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn(mvcAdmin admin)
        {
           // bool isUser=db.Cards.Any(x=>x.)
            return View("LogIn");
        }
    }
}