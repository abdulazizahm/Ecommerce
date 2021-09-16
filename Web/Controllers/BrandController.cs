using BL.AppServices;
using BL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class BrandController : Controller
    {
        // GET: Brand
        readonly BrandAppService Brands = new BrandAppService();

        public ActionResult Index()
        {
            List<BrandViewModel> brands = Brands.GetAllBrand();
            return View(brands);
        }

        [HttpGet]
        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BrandViewModel brand, HttpPostedFileBase imageFile)
        {
            ImageUploaderService imageUploader = new ImageUploaderService(imageFile, Directories.Brands);
            brand.Photo = imageUploader.GetImageName();
            if (!ModelState.IsValid)
            {
                return View(brand);
            }

            imageUploader.SaveImage();
            Brands.SaveNewBrand(brand);
           
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            return View(Brands.GetBrand(id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BrandViewModel brand, HttpPostedFileBase imageFile)
        {
            ImageUploaderService imageUploader = new ImageUploaderService(imageFile, Directories.Brands);
            brand.Photo = imageUploader.GetImageName();
            if (!ModelState.IsValid)
            {
                return View(brand);

            }
           
            Brands.UpdateBrand(brand);
            imageUploader.SaveImage();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(Brands.GetBrand(id));

        }

        public ActionResult Delete(int id)
        {
            Brands.DeleteBrand(id);
           
            return RedirectToAction("Index");
        }
    }
}