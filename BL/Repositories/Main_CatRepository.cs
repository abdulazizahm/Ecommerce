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
    public class Main_CatRepository: BaseRepository<Main_Category>
    {
        public Main_CatRepository(DbContext db):base(db)
        {
                
        }

        public List<Main_Category> GetAllMainCategories()
        {
            return GetAll().ToList();
        }

        public bool InsertMainCategory(Main_Category MainCategory)
        {
            return Insert(MainCategory);
        }
        public void UpdateMainCategory(Main_Category MainCategory)
        {
            Update(MainCategory);
        }
        public void DeleteMainCategory(int id)
        {
            Delete(id);
        }

        public bool CheckMainCategoryExists(Main_Category MainCategory)
        {
            return GetAny(b => b.Id == MainCategory.Id);
        }
        public Main_Category GetMainCategoryById(int id)
        {
            return GetFirstOrDefault(b => b.Id == id);
        }
    }
}
