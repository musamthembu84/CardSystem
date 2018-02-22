using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using LostCard.Models;

namespace LostCard.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private LostCardsEntities db = new LostCardsEntities();

        private IQueryable<Card> GetCards()
        {

        }

        [HttpPost]
        public ActionResult LogIn(mvcAdmin admin)
        {
            string userName=
            return RedirectToAction("Cards/Index");
        }
        public ActionResult LogIn(int id=0)
        {
            return View("Login");
        }
       
    }
}