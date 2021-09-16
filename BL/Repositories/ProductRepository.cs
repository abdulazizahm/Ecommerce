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
   public class ProductRepository: BaseRepository<Product>
    {
        public ProductRepository(DbContext _context):base(_context)
        {

        }
        public List<Product> GetAllBroducts()
        {
           
            return GetAll().ToList();
        }

        public bool InsertBroduct(Product product)
        {
            return Insert(product);
        }
        public void UpdateBroduct(Product product)
        {
            Update(product);
        }
        public void DeleteBroduct(int id)
        {
            Delete(id);
        }

        public bool CheckBroductExists(Product product)
        {
            return GetAny(b => b.Id == product.Id);
        }
        public Product GetBroductyId(int id)
        {
            return GetFirstOrDefault(b => b.Id == id);
        }

    }
}
