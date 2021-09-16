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
  
    public class WishListController : Controller
    {
        WishListAppService WishList_service = new WishListAppService();
        ProductAppService ProductAppService = new ProductAppService();
        AccountAppService accountAppService = new AccountAppService();

        // GET: WishList
        public ActionResult Index()
        {
            var wishList = WishList_service.GetAllWishList();
            foreach (var item in wishList)
            {
                
                item.user_Name = accountAppService.FindById(item.User_Id).UserName;
                item.product = ProductAppService.GetBroduct(item.Product_Id);
                
            }

            return View(wishList);
        }

        //public ActionResult CreateWishList()
        //{
        //    ViewData["users"] = accountAppService.GetAllUsers();
        //    ViewData["products"] = ProductAppService.GetAllBroducts();
        //    return View();
        //}
       [HttpPost]
    
        public ActionResult CreateWishList(WishListViewModel wishListViewModel)
        {
           
               
                wishListViewModel.Product_Id = wishListViewModel.Product_Id;
            ApplicationUser applicationUser = accountAppService.Find(User.Identity.Name);
            if (applicationUser != null)
            {
                wishListViewModel.User_Id = accountAppService.Find(User.Identity.Name).Id;
                WishList_service.SaveNewWishList(wishListViewModel);
                return Content("Success");
              
            }

            return Content("Register First");  
           
          

        }

        public void Delete(int id)
        {
            WishList_service.DeleteWishList(id);
            
        }


    }
}