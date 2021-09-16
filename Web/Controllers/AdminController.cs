using BL.AppServices;
using BL.ViewModels;
using DAL.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        //Account service 
        readonly AccountAppService accountAppService = new AccountAppService();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegisterAdmin() => View();

        [HttpPost]
        public ActionResult RegisterAdmin(RegisterViewModel newUser, HttpPostedFileBase imageFile)
        {
            if (!ModelState.IsValid)
                return View(newUser);

            if (accountAppService.HasEmail(newUser.Email))
            {
                ModelState.AddModelError("Email", "Email already exists");
                return View(newUser);
            }

            ImageUploaderService imageUploaderService = new ImageUploaderService(imageFile, Directories.Users);
            newUser.Photo = imageUploaderService.GetImageName();

            IdentityResult result = accountAppService.Register(newUser);
            if (result.Succeeded)
            {
                if (imageFile != null)
                    imageUploaderService.SaveImage();

                var user = accountAppService.Find(newUser.Username, newUser.PasswordHash);

                //assign admin role to user
                IdentityResult res = accountAppService.AssignToRole(user.Id, Role_Name.Admin);
                if (res.Succeeded) {


                    /////clear temp image in temp directory
                    ImageUploaderService.RecreateFolder(Directories.Temp);

                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Can't assign role Admin to user");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }


            return View(newUser);
        }


        public ActionResult RegisterAdminById(string id)
        {
            
            var user = accountAppService.FindById(id);

            if (user != null)
            {
             
                

                if (accountAppService.IsInRole(user.Id, Role_Name.Admin))
                {
                    //alert user is already an admin
                } 
                else
                {
                    IdentityResult res = accountAppService.AssignToRole(user.Id, Role_Name.Admin);
                    if (res.Succeeded)
                        return RedirectToAction("Index");
                }
            }
            else
            {
                //no user for the id Alert
            }

            return RedirectToAction("Admins");
        }

        [AllowAnonymous]
        public ActionResult Login() => RedirectToAction("Login","Account");


        public ActionResult Logout() => RedirectToAction("Logout", "Account");


        public ActionResult DeleteAdmin(string id)
        {
            if (accountAppService.IsInRole(id, Role_Name.Admin))
                accountAppService.RemoveFromRole(id, Role_Name.Admin.ToString());

            return RedirectToAction("Admins");
        }

        public ActionResult Admins()
        {
            return View(accountAppService.GetAllAdmins());
        }

        
        public ActionResult Users()
        {
            ViewBag.title = "Users";
            return View(accountAppService.GetAllUsers());
        }

        public ActionResult Vendors()
        {
            ViewBag.title = "Vendors";
            return View("Users", accountAppService.GetAllVendors());
        }
    }
}