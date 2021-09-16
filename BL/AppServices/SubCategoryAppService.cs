using BL.Bases;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class SubCategoryAppService : BaseAppService
    {
        #region CURD

        public List<Sub_Category> GetAllSubCategories()
        {
            return Mapper.Map<List<Sub_Category>>(TheUnitOfWork.SubCategory.GetAllSubCategories());
        }
        public Sub_Category GetSubCategory(int id)
        {
            return Mapper.Map<Sub_Category>(TheUnitOfWork.SubCategory.GetSubCategoryById(id));
        }



        public bool SaveNewSubCategory(Sub_Category SubCategory)
        {
            bool result = false;
            var subcategory = Mapper.Map<Sub_Category>(SubCategory);
            if (TheUnitOfWork.SubCategory.Insert(subcategory))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateSubCategory(Sub_Category SubCategory)
        {
            //var subcategory = Mapper.Map<Sub_Category>(SubCategory);
            TheUnitOfWork.SubCategory.Update(SubCategory);
            TheUnitOfWork.Commit();

            return true;
        }
        public void UpdateNormal(Sub_Category SubCategory) // problem  in update becouse use same entity
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var subcategory = db.Sub_Categories.Where(s => s.Id == SubCategory.Id).FirstOrDefault();
            subcategory.Name = SubCategory.Name;
            subcategory.Parent_Id = SubCategory.Parent_Id;
            subcategory.Cat_Id = SubCategory.Cat_Id;
            subcategory.Photo = subcategory.Photo;
            db.SaveChanges();
        }


        public bool DeleteSubCategory(int id)
        {
            TheUnitOfWork.SubCategory.Delete(id);
            bool result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckSubCategoryExists(Sub_Category SubCategory)
        {
            Sub_Category subcategory= Mapper.Map<Sub_Category>(SubCategory);
            return TheUnitOfWork.SubCategory.CheckSubCategoryExists(subcategory);
        }
        #endregion
    }
}
