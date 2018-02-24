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


       
        // GET: Auth
       /* public ActionResult Index()
        {
            return View();
        }*/

        public ActionResult LogIn(int id =0)
        {
            return View();
        }

       [HttpPost]
        public ActionResult LogIn(mvcAdmin admin)
        {
               bool isPass = db.UserTables.Any(y => y.Password == admin.Password);

                if (isPass == true)
                {
                    return RedirectToAction("~/Home/Index");
                }
                else
                {
                    ViewBag.status = "Incorrect username and password";
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