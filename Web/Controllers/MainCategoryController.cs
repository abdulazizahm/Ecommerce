using BL.AppServices;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class MainCategoryController : Controller
    {
        readonly Main_CatAppService main_CatApp = new Main_CatAppService();
        // GET: MainCategory
        public ActionResult Index()
        {
            return View(main_CatApp.GetAllMain_Category());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Main_Category main_Cat, HttpPostedFileBase imageFile)
        {
            ImageUploaderService imageUploader = new ImageUploaderService(imageFile, Directories.Main_Categories);
           main_Cat.Photo = imageUploader.GetImageName();
            if (!ModelState.IsValid)
            {
                return View(main_Cat);
            }
            
            main_CatApp.SaveNewMain_Category(main_Cat);
            imageUploader.SaveImage();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(main_CatApp.GetMain_Category(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Main_Category main_Cat, HttpPostedFileBase imageFile)
        {
            ImageUploaderService imageUploader = new ImageUploaderService(imageFile, Directories.Main_Categories);
            main_Cat.Photo = imageUploader.GetImageName();
            if (!ModelState.IsValid)
            {
                return View(main_Cat);
            }
            main_CatApp.UpdateMain_Category(main_Cat);
            imageUploader.SaveImage();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(main_CatApp.GetMain_Category(id));
        }

        public ActionResult Delete(int id)
        {
            main_CatApp.DeleteMain_Category(id);
            return RedirectToAction("Index");
        }
    }
}