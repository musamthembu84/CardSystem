using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LostCard.Models;
using System.Data.Entity;

namespace LostCard.Controllers
{
    public class AuthController : Controller
    {
        private LostCardsEntities db = new LostCardsEntities();


        private IQueryable<UserTable> GetCards()
        {

           return db.UserTable;
        }
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn(mvcAdmin admin)
        {
            // bool isUser=db.Cards.Any(x=>x.)

            bool isUser = db.UserTable.Any(x => x.UserName == admin.UserName);
            bool isPass = db.UserTable.Any(y => y.Password == admin.Password);

            if (isUser==true && isPass == true)
            {
                return RedirectToAction("~/Home/Index");
            }
            else
            {
                ViewBag.status = "Incorrect username and password";
                return View("Login", admin);
            }
           
        }
    }
}