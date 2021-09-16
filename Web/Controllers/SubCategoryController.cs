using BL.AppServices;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{

    public class SubCategoryController : Controller
    {
        // GET: SubCategory
        //Admin
         SubCategoryAppService subCategory = new SubCategoryAppService();
         Main_CatAppService main_CatApp = new Main_CatAppService();
        public ActionResult Index()
        {
            //ViewBag.Main = main_CatApp.GetAllMain_Category();
            List<Sub_Category> sub_Categories = subCategory.GetAllSubCategories();
            foreach( var item in sub_Categories) 
            {
                item.Main_Category = main_CatApp.GetMain_Category(item.Cat_Id);
            }
            return View(sub_Categories);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Parent = subCategory.GetAllSubCategories();
            ViewBag.Main = main_CatApp.GetAllMain_Category();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, Sub_Category sub_Category)
        {
            ViewBag.Parent = subCategory.GetAllSubCategories();
            ViewBag.Main = main_CatApp.GetAllMain_Category();
            ImageUploaderService imageupload= new ImageUploaderService(file, Directories.Sub_Categories);
            bool notnull = false;
            if (sub_Category.Parent_Id == 0) 
            {
                sub_Category.Parent_Id = null;
            }
            if (imageupload.GetImageName() != null)
            {
                notnull = true;
                sub_Category.Photo = imageupload.GetImageName();
            }
            if (!ModelState.IsValid) 
            {
                return View(sub_Category);
            }
          
              try 
              {
                    subCategory.SaveNewSubCategory(sub_Category);
                    if (notnull) 
                    {
                        imageupload.SaveImage();
                    }
              }
            catch(Exception ex) 
              {
                    ModelState.AddModelError("", ex.Message);
                    return View(sub_Category);
              }
           return RedirectToAction("Index", "SubCategory");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Parent = subCategory.GetAllSubCategories().Where(s => s.Id != id);
            ViewBag.Main = main_CatApp.GetAllMain_Category();
            return View(subCategory.GetSubCategory(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase file, Sub_Category sub_Category)
        {
            ViewBag.Parent = subCategory.GetAllSubCategories().Where(s => s.Id != sub_Category.Id);
            ViewBag.Main = main_CatApp.GetAllMain_Category();
            ImageUploaderService imageupload = new ImageUploaderService(file, Directories.Sub_Categories);
            bool notnull = false;
            if (sub_Category.Parent_Id == 0)
            {
                sub_Category.Parent_Id = null;
            }
            if (imageupload.GetImageName() != null)
            {
                ImageUploaderService.DeleteImage(sub_Category.Photo, Directories.Sub_Categories);
                notnull = true;
                sub_Category.Photo = imageupload.GetImageName();
            }
            if (!ModelState.IsValid)
            {
                return View(sub_Category);
            }
            try
            {
                subCategory.UpdateNormal(sub_Category);
                if (notnull)
                {
                    imageupload.SaveImage();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(sub_Category);
            }
            return RedirectToAction("Index", "SubCategory");
        }
        public ActionResult Delete(int id)
        {
            subCategory.DeleteSubCategory(id);
            return RedirectToAction("Index");
        }
    }
}