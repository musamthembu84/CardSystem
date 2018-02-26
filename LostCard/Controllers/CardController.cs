using System;
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
        private LostCardsEntities1 db = new LostCardsEntities1();
        // GET: Card
        public ActionResult Index()
        {
            if (Session["uname"] == null)
            {
                return RedirectToAction("LogIn", "Auth");
            }
            IEnumerable<mvcCards> myList = null;
            HttpResponseMessage response = GlobalVariables.webApi.GetAsync("Cards").Result;
            myList = response.Content.ReadAsAsync<IEnumerable<mvcCards>>().Result;
            return View(myList);
        }



        public IQueryable <Card> GetCards()
        {
            return db.Cards;

        }


       


        public ActionResult Register(int i = 0)
        {
            if (Session["uname"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                return View(new mvcCards());
            }
          
        }

        [HttpPost]
        public ActionResult Register(mvcCards student)
        {
           
                try
                {
                    bool anyUserExists = db.Cards.Any(x => x.SNumber == student.SNumber);

                    if (anyUserExists == true)
                    {
                    TempData["Student"] = student.SNumber;
                    return RedirectToAction("CardAvail");

                    }

                    else
                    {

                        EmailConfiguration emails = new EmailConfiguration();
                        bool isValid = emails.Email(student);
                        if (isValid == true)
                        {
                            return RedirectToAction("Failed");
                        }
                        else
                        {
                            HttpResponseMessage response = GlobalVariables.webApi.PostAsJsonAsync("Cards", student).Result;
                            TempData["SuccessMessage"] = "Saved Successfully";
                            TempData["CardNumber"] = student.SNumber;
                            return RedirectToAction("Success");
                        }

                    }
                }
                catch (Exception Ex)
                {
                    Ex.GetBaseException();
                    return RedirectToAction("Failed");
                }
           

           

           
           
        }





        [HttpPost]
        public ActionResult Search(mvcCards student)
        {
            
                bool isCard = db.Cards.Any(x => x.SNumber == student.SNumber);

                if (isCard == true)
                {
                   TempData["Student"] = student.SNumber;
                   return RedirectToAction("CardAvail");
                }

                else
                {
                TempData["Student"] = student.SNumber;
                return RedirectToAction("NotAvailable");
                }
           
           
            
        }

        [HttpPost]
        public ActionResult Removal(mvcCards student)
        {
             Card record = db.Cards.SingleOrDefault(x => x.SNumber == student.SNumber);
                if (record == null)
                {
                TempData["Student"] = student.SNumber;
                return RedirectToAction("NotAvailable");
                }

                TempData["Delete"] = student.SNumber;
                db.Cards.Remove(record);
                db.SaveChanges();
                
                return RedirectToAction("RemoveSuccess");
           
           
           
        }


        public ActionResult Success(mvcCards student)
        {
            if (Session["uname"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            ViewBag.Success = TempData["CardNumber"];
            return View(new mvcCards());
        }

        public ActionResult RemoveSuccess(mvcCards student )
        {
            if (Session["uname"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            ViewBag.this_student_card = TempData["Delete"];
            return View(new mvcCards());
        }
        public ActionResult Failed(int id = 0)
        {
            if (Session["uname"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            return View(new mvcCards());
        }

        public ActionResult Removal(int id = 0)
        {
            if (Session["uname"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View(new mvcCards());
        }
        public ActionResult Search (int id = 0)
        {
            if (Session["uname"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View(new mvcCards());
        }

        public ActionResult NotAvailable(mvcCards student)
        {
            if (Session["uname"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            ViewBag.this_student_card = TempData["Student"];
            return View(new mvcCards());

        }

        public ActionResult LogOut(mvcCards student)
        {
            if (Session["uname"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            Session.Remove("uname");
            return RedirectToAction("Login", "Auth");

        }

        public ActionResult CardAvail(mvcCards student)
        {
             if (Session["uname"] == null)
             {
                 return RedirectToAction("Login", "Auth");
             }

             else
             {
                 ViewBag.Message = TempData["Student"];
                 string found = (string)TempData["Student"];
                 string lost = db.Cards.Where(x => x.SNumber == found).Select(u => u.Campus).FirstOrDefault();
                 ViewBag.studentCampus = lost;
                return View(new mvcCards());

             }



        }





    }
}