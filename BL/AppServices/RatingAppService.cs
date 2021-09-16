using AutoMapper;
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
    public class RatingAppService : BaseAppService
    {
        #region CURD

        public List<RatingViewModel> GetAllRating()
        {
            return Mapper.Map<List<RatingViewModel>>(TheUnitOfWork.Rating.GetAllRatings());
        }
        public RatingViewModel GetRating(int id)
        {
            return Mapper.Map<RatingViewModel>(TheUnitOfWork.Rating.GetRatingById(id));
        }



        public bool SaveNewRating(RatingViewModel RatingViewModel)
        {
            bool result = false;
            var Rating = Mapper.Map<Rating>(RatingViewModel);
            if (TheUnitOfWork.Rating.Insert(Rating))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateRating(RatingViewModel RatingViewModel)
        {
            var Rating = Mapper.Map<Rating>(RatingViewModel);
            TheUnitOfWork.Rating.Update(Rating);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteRating(int id)
        {
            TheUnitOfWork.Rating.Delete(id);
            bool result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckRatingExists(RatingViewModel RatingViewModel)
        {
            Rating Rating = Mapper.Map<Rating>(RatingViewModel);
            return TheUnitOfWork.Rating.CheckRatingExists(Rating);
        }
        #endregion
    }
}
