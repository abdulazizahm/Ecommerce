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
  public  class ProductAppService :BaseAppService
    {
        public List<ProductViewModel> GetAllBroducts()
        {
             return Mapper.Map<List<ProductViewModel>>(TheUnitOfWork.Product.GetAllBroducts());
    
        }
        public ProductViewModel GetBroduct(int id)
        {
            return Mapper.Map<ProductViewModel>(TheUnitOfWork.Product.GetBroductyId(id));
        }
        public bool SaveNewBroduct(ProductViewModel productViewModel)
        {
            bool result = false;
            var product = Mapper.Map<Product>(productViewModel);
            if (TheUnitOfWork.Product.Insert(product))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool UpdateBroduct(ProductViewModel productViewModel)
        {
            var product = Mapper.Map<Product>(productViewModel);
            TheUnitOfWork.Product.Update(product);
            TheUnitOfWork.Commit();

            return true;
        }
        public bool DeleteBroduct(int id)
        {
            TheUnitOfWork.Product.Delete(id);
            bool result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckBroductExists(ProductViewModel productViewModel)
        {
            Product product = Mapper.Map<Product>(productViewModel);
            return TheUnitOfWork.Product.CheckBroductExists(product);
        }
    }
}
