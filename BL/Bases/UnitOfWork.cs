using BL.Interfaces;
using BL.Repositories;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Bases
{
    public class UnitOfWork : IUnitOfWork
    {

        #region Shared Props
        private DbContext EC_Context { get; set; }
        #endregion


        #region Props and Data Fields
        private AccountRepository account;
        public AccountRepository Account
        {
            get
            {
                account = account ?? new AccountRepository(EC_Context);
                return account;
            }
        }

        private RoleRepository role;
        public RoleRepository Role
        {
            get
            {
                role = role ?? new RoleRepository(EC_Context);
                return role;
            }
        }

        private BrandRepositoty brand;
        public BrandRepositoty Brand
        {
            get
            {
                brand = brand ?? new BrandRepositoty(EC_Context);
                return brand;
            }
        }

        public ProductRepository product;
        public ProductRepository Product
        {
            get
            {
                product = product ?? new ProductRepository(EC_Context);
                return product;
            }
        }

        private Main_CatRepository mainCategory;
        public Main_CatRepository MainCategory
        {
            get
            {
                mainCategory = mainCategory ?? new Main_CatRepository(EC_Context);
                return mainCategory;
            }
        }
        
        private SubCategoryRespository subCategory;
        public SubCategoryRespository SubCategory
        {
            get
            {
                subCategory = subCategory ?? new SubCategoryRespository(EC_Context);
                return subCategory;
            }
        }

        private WishListRepository wishList;
        public WishListRepository WishList
        {
            get
            {
                wishList = wishList ?? new WishListRepository(EC_Context);
                return wishList;
            }
        }
        private RatingRepository rating;
        public RatingRepository Rating
        {
            get
            {
                rating = rating ?? new RatingRepository(EC_Context);
                return rating;
            }
        }

        // Main_CatRepository IUnitOfWork.mainCategory => throw new NotImplementedException();
        #endregion

        #region CTOR

        public UnitOfWork()
        {
            EC_Context = new ApplicationDbContext();
            //EC_Context.Configuration.LazyLoadingEnabled = false;
        }
        #endregion


        #region Methods

        public int Commit()
        {
            return EC_Context.SaveChanges();
        }

        public void Dispose()
        {
            EC_Context.Dispose();
        }
        #endregion
    }
}
