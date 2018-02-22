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
        private LostCardsEntities db = new LostCardsEntities();
        private string location;
        // GET: Card
        public ActionResult Index()
        {
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
            return View(new mvcCards());
        }

        [HttpPost]
        public ActionResult Register(mvcCards student)
        {


            bool anyUserExists = db.Cards.Any(x => x.SNumber == student.SNumber);

            if (anyUserExists == true)
            {

                return RedirectToAction("CardAvailable",student);
                
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
                    return RedirectToAction("Index");
                }
                
            }
           
        }





        [HttpPost]
        public ActionResult Search(mvcCards student)
        {
            bool isCard = db.Cards.Any(x => x.SNumber == student.SNumber);

            if (isCard == true)
            {
              return  RedirectToAction("CardAvailable",student);
            }

            else
            {
               return RedirectToAction("NotAvailable",student);
            }
            
        }

        public ActionResult Removal(mvcCards student)
        {
            Card record = db.Cards.SingleOrDefault(x => x.SNumber == student.SNumber);
            if (record == null)
            {
                return RedirectToAction("NotAvailable", student);   
            }

            db.Cards.Remove(record);
            db.SaveChanges();
           
           return RedirectToAction("Removal", student);
           
        }

        public ActionResult Removal(int id = 0)
        {
            ViewBag.this_student_card = student.SNumber;
            return View(new mvcCards());
        }
        public ActionResult Failed(int id = 0)
        {
            return View(new mvcCards());
        }
        public ActionResult Search (int id = 0)
        {
            return View(new mvcCards());
        }

        public ActionResult NotAvailable(mvcCards student)
        {
            ViewBag.this_student_card = student.SNumber;
            return View(new mvcCards());

        }

        public ActionResult CardAvailable(mvcCards student)
        {

            ViewBag.studentCard = student.SNumber;
            string lost = db.Cards.Where(x => x.SNumber == student.SNumber).Select(u => u.Campus).FirstOrDefault();
            ViewBag.studentCampus = lost;
            return View(new mvcCards());
        }





    }
}