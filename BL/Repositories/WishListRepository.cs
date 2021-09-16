using BL.Bases;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
   public class WishListRepository: BaseRepository<WishList>
    {
        public WishListRepository(DbContext db) : base(db)
        {
        }

        #region CRUB

        public List<WishList> GetAllWishLists()
        {
            return GetAll().ToList();
        }

        public bool InsertWishList(WishList WishList)
        {
            return Insert(WishList);
        }
        public void UpdateWishList(WishList WishList)
        {
            Update(WishList);
        }
        public void DeleteWishList(int id)
        {
            Delete(id);
        }

        public bool CheckWishListExists(WishList WishList)
        {
            return GetAny(b => b.Id == WishList.Id);
        }
        public WishList GetWishListById(int id)
        {
            return GetFirstOrDefault(b => b.Id == id);
        }
        #endregion
    }
}
