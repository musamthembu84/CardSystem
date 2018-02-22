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

        [HttpPost]
        public ActionResult LogIn(mvcCards admin)
        {
            return View("Login");
        }
       
    }
}