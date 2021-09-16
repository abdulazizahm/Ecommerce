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
    public class SubCategoryRespository:BaseRepository<Sub_Category>
    {
        public SubCategoryRespository(DbContext db) : base(db)
        {

        }
        public List<Sub_Category> GetAllSubCategories()
        {
            return GetAll().ToList();
        }

        public bool InsertSubCategory(Sub_Category Sub_Category)
        {
            return Insert(Sub_Category);
        }
        public void UpdateSubCategory(Sub_Category Sub_Category)
        {
            Update(Sub_Category);
        }
        public void DeleteSubCategory(int id)
        {
            Delete(id);
        }

        public bool CheckSubCategoryExists(Sub_Category Sub_Category)
        {
            return GetAny(s => s.Id == Sub_Category.Id);
        }
        public Sub_Category GetSubCategoryById(int id)
        {
            return GetFirstOrDefault(s => s.Id == id);
        }

    }
}
