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

                location = student.Campus;
                return RedirectToAction("CardAvailable",student);
                
            }

            else
            {
                HttpResponseMessage response = GlobalVariables.webApi.PostAsJsonAsync("Cards", student).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
                return RedirectToAction("Index");
            }
           
        }











        public ActionResult CardAvailable(mvcCards student)
        {


            

            ViewBag.stu = student.SNumber;
             var logs = db.Cards.Where(x => x.SNumber == student.SNumber).ToList();


            string lost = db.Cards.Where(x => x.SNumber == student.SNumber).Select(u => u.Campus).FirstOrDefault();

             ViewBag.lo = lost;


            return View(new mvcCards());
        }





    }
}