using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LostCard.Models;
using System.Data.Entity;
using System.Net.Http;
using System.Web.SessionState;

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



       [HttpPost]
        public ActionResult SignIn(mvcAdmin admin)
        {
               bool isPass = db.UserTables.Any(y => y.Password == admin.Password);
               bool isUser = db.UserTables.Any(z => z.UserName == admin.UserName);
               var obj = db.UserTables.Where(a => a.UserName.Equals(admin.UserName) && a.Password.Equals(admin.Password)).FirstOrDefault();

            if (isPass == true  && isUser==true)
                {


                Session["uname"] = admin.UserName;
                Session.Timeout = 10;
                return RedirectToAction("Index","Card");
                }
                else
                {
                TempData["SuccessMessage"] = "Incorrect username or password";
                return View("Login", admin);
                }
            


           
        }


       
        public ActionResult SignIn(int id=0)
        {
            return View();
        }

        public ActionResult LogIn(int id = 0)
        {
            return View();
        }
    }
}