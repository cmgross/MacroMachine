using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MacroMachine.Models;
using Microsoft.Owin.Security.Facebook;

namespace MacroMachine.Controllers
{
    [RequireHttps]
    [Authorize]
    public class ProfileController : Controller
    {
        // GET: Profile
        [HttpGet]
        public ActionResult Index()
        {
            var profileViewModel = new ProfileIndexViewModel(User.Identity.Name);
            return View(profileViewModel);
        }

        [HttpPost]
        public ActionResult Index(ApplicationUser profile)
        {
            return View();
        }
    }
}
