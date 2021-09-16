using BL.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.ViewModels;

namespace Web.Controllers
{
    public class UproductController : Controller
    {
        // GET: Uproduct
        ProductAppService ProductAppService = new ProductAppService();
        BrandAppService BrandAppService = new BrandAppService();
        AccountAppService accountAppService = new AccountAppService();
        SubCategoryAppService subCategoryAppService = new SubCategoryAppService();
        RatingAppService ratingAppService = new RatingAppService();
        public ActionResult details(int id)
        {
            var prod = ProductAppService.GetBroduct(id);
            prod.Vendor_Name = accountAppService.FindById(prod.Vendor_User_id).UserName;
            var rating = ratingAppService.GetAllRating().Where(r => r.Product_Id == id);
            ViewBag.RatingProd= rating.Take(3);
            int count = rating.Count();
            ViewBag.count = count;
            int sum = 0;
            foreach (var item in ViewBag.RatingProd)
            {
                sum += item.Rate;
            }
            int aveg=0;
            if (count != 0) 
            {
                aveg = (sum / count);
            }
            if (aveg != 0) 
            {
                ViewBag.pres = (double)sum / (double)(5 * count);
                ViewBag.rat5 = rating.Where(r => r.Rate == 5).Count();
                ViewBag.rat4 = rating.Where(r => r.Rate == 4).Count();
                ViewBag.rat3 = rating.Where(r => r.Rate == 3).Count();
                ViewBag.rat2 = rating.Where(r => r.Rate == 2).Count();
                ViewBag.rat1 = rating.Where(r => r.Rate == 1).Count();
                int sumrat = ViewBag.rat1 + ViewBag.rat2 + ViewBag.rat3 + ViewBag.rat4 + ViewBag.rat5;
                ViewBag.rat5pres = ((double)ViewBag.rat5 / (double)sumrat)*100.0;
                ViewBag.rat4pres = ((double)ViewBag.rat4 / (double)sumrat)*100.0;
                ViewBag.rat3pres = ((double)ViewBag.rat3 / (double)sumrat)*100.0;
                ViewBag.rat2pres = ((double)ViewBag.rat2 / (double)sumrat)*100.0;
                ViewBag.rat1pres = ((double)ViewBag.rat1 / (double)sumrat)*100.0;
            }
            
            //ViewBag.presrat5 = pres;
            ViewBag.aveg = aveg;
            foreach (var item in ViewBag.RatingProd)
            {
                item.User = accountAppService.FindById(item.User_Id);
            }

            ViewBag.products = ProductAppService.GetAllBroducts().Where(p => p.Sub_Cat_Id == prod.Sub_Cat_Id).Take(5);
            foreach (var item in ViewBag.products)
            {
                item.Brand = BrandAppService.GetBrand(item.Brand_Id);
                item.Vendor_Name = accountAppService.FindById(item.Vendor_User_id).UserName;
                item.Sub_Category = subCategoryAppService.GetSubCategory(item.Sub_Cat_Id);
            }
            return View(prod);
        }
        public ActionResult AddRate(RatingViewModel ratingViewModel)
        {
          if (User.Identity.IsAuthenticated) 
            {
                ratingViewModel.User_Id = accountAppService.Find(User.Identity.Name).Id;
                if (ratingAppService.GetAllRating().Where(r=>r.User_Id== ratingViewModel.User_Id && r.Product_Id== ratingViewModel.Product_Id).Count()==0)
                {
                    if (ratingViewModel.Rate == null) 
                    {
                        ratingViewModel.Rate = 3;
                    }
                    
                    ratingViewModel.Created_at = DateTime.Now;
                    ratingAppService.SaveNewRating(ratingViewModel);
                }
            }
            return RedirectToAction("details", new { id = ratingViewModel.Product_Id });
        }
    }
}