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
    public class RatingRepository: BaseRepository<Rating>
    {
        public RatingRepository(DbContext db) : base(db)
        {
        }

        #region CRUB

        public List<Rating> GetAllRatings()
        {
            return GetAll().ToList();
        }

        public bool InsertRating(Rating Rating)
        {
            return Insert(Rating);
        }
        public void UpdateRating(Rating Rating)
        {
            Update(Rating);
        }
        public void DeleteRating(int id)
        {
            Delete(id);
        }

        public bool CheckRatingExists(Rating Rating)
        {
            return GetAny(b => b.Id == Rating.Id);
        }
        public Rating GetRatingById(int id)
        {
            return GetFirstOrDefault(b => b.Id == id);
        }
        #endregion
    }
}
