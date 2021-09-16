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
    public class BrandAppService: BaseAppService
    {
        #region CURD
       
        public List<BrandViewModel> GetAllBrand()
        {
            return Mapper.Map<List<BrandViewModel>>(TheUnitOfWork.Brand.GetAllBrands());
        }
        public BrandViewModel GetBrand(int id)
        {
            return Mapper.Map<BrandViewModel>(TheUnitOfWork.Brand.GetBrandById(id));
        }



        public bool SaveNewBrand(BrandViewModel BrandViewModel)
        {
            bool result = false;
            var brand = Mapper.Map<Brand>(BrandViewModel);
            if (TheUnitOfWork.Brand.Insert(brand))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateBrand(BrandViewModel BrandViewModel)
        {
            var Brand = Mapper.Map<Brand>(BrandViewModel);
            TheUnitOfWork.Brand.Update(Brand);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteBrand(int id)
        {
            TheUnitOfWork.Brand.Delete(id);
            bool result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckBrandExists(BrandViewModel BrandViewModel)
        {
            Brand Brand = Mapper.Map<Brand>(BrandViewModel);
            return TheUnitOfWork.Brand.CheckBrandExists(Brand);
        }
        #endregion
    }
}
