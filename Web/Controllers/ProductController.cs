using BL.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Model;
using System.Web.Mvc;
using BL.ViewModels;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        ProductAppService ProductAppService = new ProductAppService();
        BrandAppService BrandAppService = new BrandAppService();
        AccountAppService accountAppService = new AccountAppService();
        SubCategoryAppService subCategoryAppService = new SubCategoryAppService();
        // GET: Product
        public ActionResult Index()
        {
            var products = ProductAppService.GetAllBroducts();
            foreach (var item in products)
            {
                item.Brand = BrandAppService.GetBrand(item.Brand_Id);
                item.Vendor_Name = accountAppService.FindById(item.Vendor_User_id).UserName;
                item.Sub_Category = subCategoryAppService.GetSubCategory(item.Sub_Cat_Id);
            }

          

            return View(products);
        }
        public ActionResult CreateProduct()
        {
            ViewData["Brands"] = BrandAppService.GetAllBrand();
         // ViewData["Vendors"] = accountAppService.GetUserByRole(Role_Name.Vendor);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct(ProductViewModel productViewModel, HttpPostedFileBase imageFile)
        {
            ViewData["Brands"] = BrandAppService.GetAllBrand();
            if (ModelState.IsValid)
            {
                ImageUploaderService imageUploaderService = new ImageUploaderService(imageFile, Directories.Products);
                productViewModel.Photo = imageUploaderService.GetImageName();

                ProductAppService.SaveNewBroduct(productViewModel);

                imageUploaderService.SaveImage();
                TempData["success"] = "Success Add Product";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["failed"] = "failed to Add Product";
                return View(productViewModel);
            }
          
        }
        public ActionResult UpdateProduct(int id)
        {
           
            return View(ProductAppService.GetBroduct(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProduct(ProductViewModel productViewModel,HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid) {
                ImageUploaderService imageUploaderService = new ImageUploaderService(imageFile, Directories.Products);
                productViewModel.Photo = imageUploaderService.GetImageName();
                ProductAppService.UpdateBroduct(productViewModel);
                imageUploaderService.SaveImage();
                TempData["success"] = "Success Update Product";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["failed"] = "failed to Update Product";
                ModelState.AddModelError("", "Error in Update");
                return View(productViewModel);
            }

        }

        public ActionResult DeleteProduct(int id)
        {
           
            ProductAppService.DeleteBroduct(id);
            TempData["successDelete"] = "Success Delete Product";
            return RedirectToAction("Index");
        }
    }
}