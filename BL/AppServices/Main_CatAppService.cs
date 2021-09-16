using AutoMapper;
using BL.Bases;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
   public class Main_CatAppService:BaseAppService
    {
        #region CURD

        public List<Main_Category> GetAllMain_Category()
        {
            return Mapper.Map<List<Main_Category>>(TheUnitOfWork.MainCategory.GetAllMainCategories());
        }
        public Main_Category GetMain_Category(int id)
        {
            return Mapper.Map<Main_Category>(TheUnitOfWork.MainCategory.GetMainCategoryById(id));
        }



        public bool SaveNewMain_Category(Main_Category Main_Category)
        {
            bool result = false;
            var main_Cat = Mapper.Map<Main_Category>(Main_Category);
            if (TheUnitOfWork.MainCategory.Insert(main_Cat))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateMain_Category(Main_Category Main_Category)
        {
            var main_Cat = Mapper.Map<Main_Category>(Main_Category);
            TheUnitOfWork.MainCategory.Update(main_Cat);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteMain_Category(int id)
        {
            TheUnitOfWork.MainCategory.Delete(id);
            bool result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckMain_CategoryExists(Main_Category Main_Category)
        {
            Main_Category main_Cat = Mapper.Map<Main_Category>(Main_Category);
            return TheUnitOfWork.MainCategory.CheckMainCategoryExists(main_Cat);
        }
        #endregion
    }
}
