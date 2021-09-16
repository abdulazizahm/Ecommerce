using BL.AppServices;
using BL.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        readonly RoleAppService roleAppService = new RoleAppService();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RoleViewModel role)
        {
            if (!ModelState.IsValid)
                return View(role);
            IdentityResult result = roleAppService.Create(role.Name);

            if (result.Succeeded)
                return RedirectToAction("Index", "Admin");
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
            return View(role);
        }
    }
}