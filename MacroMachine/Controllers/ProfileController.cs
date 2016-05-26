using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MacroMachine.Models;

namespace MacroMachine.Controllers
{
    [RequireHttps]
    [Authorize]
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            var user = ApplicationUser.Get(User.Identity.Name);
            return View();
       
        //TODO don't worry about checking for the profile yet..literally just worry about creating/editing the profile fields here, use some jquery
    }
    }
}