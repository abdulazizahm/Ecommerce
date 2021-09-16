using BL.AppServices;

using BL.ViewModels;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class MainSiteController : Controller
    {
       
        Main_CatAppService mainCategoryAppService = new Main_CatAppService();
        ProductAppService ProductAppService = new ProductAppService();
        AccountAppService accountAppService = new AccountAppService();
        SubCategoryAppService SubCategoryAppService = new SubCategoryAppService();
        // GET: MainSite
        public ActionResult Index()
        {
            VariationOfProductsViewModel variationOfProductsViewModel = new VariationOfProductsViewModel();
            List<ProductViewModel> Products = ProductAppService.GetAllBroducts();
            variationOfProductsViewModel.ProductViewModels = Products;
            variationOfProductsViewModel.vendors = accountAppService.GetAllVendors();

            return View(variationOfProductsViewModel);
        }
        public ActionResult NavBarData()
        {
            if (Session["cart"] != null)
                ViewBag.cartCount = ((List<Item>)Session["cart"]).Count;
            List<Sub_Category> sub_Categories = SubCategoryAppService.GetAllSubCategories().Where(s=>s.Parent_Id==null).ToList();
            return PartialView("_NavBarView", sub_Categories);
        }
       

        public ActionResult ShowProductByCategory(int sub_cat_id)
        {

         List<ProductViewModel> products= ProductAppService.GetAllBroducts().Where(p => p.Sub_Cat_Id == sub_cat_id).ToList();
            return View(products);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(SearchViewModel searchViewModel)
        {
            if (searchViewModel.SubCatId!=0)
            {
                List<ProductViewModel> products = ProductAppService.GetAllBroducts().Where(p => p.Sub_Cat_Id == searchViewModel.SubCatId && p.Name==searchViewModel.SearchText).ToList();
                return View("ShowProductByCategory", products);
            }
            else
            {
                List<ProductViewModel> products = ProductAppService.GetAllBroducts().Where(p =>  p.Name == searchViewModel.SearchText.ToLower()).ToList();
                return View("ShowProductByCategory", products);
                
                
             
            }
        }
        public ActionResult GetProductByStore(int vendorID)
        {
          
          
                List<ProductViewModel> products = ProductAppService.GetAllBroducts().Where(p => p.Vendor_User_id == p.Vendor_User_id).ToList();
                return View("ShowProductByCategory", products);
            
        }
    }
}