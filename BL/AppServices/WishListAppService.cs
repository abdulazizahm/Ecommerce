using BL.Bases;
using BL.ViewModels;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class WishListAppService:BaseAppService
    {
        #region CURD

        public List<WishListViewModel> GetAllWishList()
        {
            return Mapper.Map<List<WishListViewModel>>(TheUnitOfWork.WishList.GetAllWishLists());
        }
        public WishListViewModel GetWishList(int id)
        {
            return Mapper.Map<WishListViewModel>(TheUnitOfWork.WishList.GetWishListById(id));
        }



        public bool SaveNewWishList(WishListViewModel WishListViewModel)
        {
            bool result = false;
            var wishList = Mapper.Map<WishList>(WishListViewModel);
            if (TheUnitOfWork.WishList.Insert(wishList))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateWishList(WishListViewModel WishListViewModel)
        {
            var wishList = Mapper.Map<WishList>(WishListViewModel);
            TheUnitOfWork.WishList.Update(wishList);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteWishList(int id)
        {
            TheUnitOfWork.WishList.Delete(id);
            bool result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckWishListExists(WishListViewModel WishListViewModel)
        {
            WishList WishList = Mapper.Map<WishList>(WishListViewModel);
            return TheUnitOfWork.WishList.CheckWishListExists(WishList);
        }
        #endregion
    }
}
