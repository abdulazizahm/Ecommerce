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
    public class BrandRepositoty: BaseRepository<Brand>
    {
        public BrandRepositoty(DbContext db):base(db)
        {
        }

        #region CRUB

        public List<Brand> GetAllBrands()
        {
            return GetAll().ToList();
        }

        public bool InsertBrand(Brand Brand)
        {
            return Insert(Brand);
        }
        public void UpdateBrand(Brand Brand)
        {
            Update(Brand);
        }
        public void DeleteBrand(int id)
        {
            Delete(id);
        }

        public bool CheckBrandExists(Brand Brand)
        {
            return GetAny(b => b.Id == Brand.Id);
        }
        public Brand GetBrandById(int id)
        {
            return GetFirstOrDefault(b => b.Id == id);
        }
        #endregion
    }
}
