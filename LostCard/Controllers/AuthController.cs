using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LostCard.Models;
using System.Data.Entity;
using System.Net.Http;

namespace LostCard.Controllers
{
    public class AuthController : Controller
    {
        private LostCardsEntities1 db = new LostCardsEntities1();


        private IQueryable<UserTable> GetCards()
        {

           return db.UserTables;
        }

        public ActionResult Done()
        {
            return View(new mvcAdmin());
        }

        public ActionResult LogIn(int id =0)
        {
            return View();
        }

       [HttpPost]
        public ActionResult LogIn(mvcAdmin admin)
        {
               bool isPass = db.UserTables.Any(y => y.Password == admin.Password);
               bool isUser = db.UserTables.Any(z => z.UserName == admin.UserName);
                if (isPass == true)
                {
                    return RedirectToAction("Index","Card");
                }
                else
                {
                TempData["SuccessMessage"] = "Incorrect username or password";
                return View("Login", admin);
                }
            


           
        }


        [HttpPost]
        public ActionResult SignIn(mvcAdmin admin)
        {
            HttpResponseMessage response = GlobalVariables.webApi.PostAsJsonAsync("UserTable", admin).Result;

            return RedirectToAction("Done");
        }
    }
}