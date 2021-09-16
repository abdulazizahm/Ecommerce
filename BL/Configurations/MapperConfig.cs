using AutoMapper;
using BL.ViewModels;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Configurations
{
    static class MapperConfig
    {
        public static IMapper Mapper { get; set; }

        static MapperConfig()
        {
            var conig = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<ApplicationUser, LoginViewModel>().ReverseMap();
                    cfg.CreateMap<ApplicationUser, RegisterViewModel>().ReverseMap();
                    cfg.CreateMap<ApplicationUser, AdminDisplayUserViewModel>().ReverseMap();
                    cfg.CreateMap<Brand, BrandViewModel>().ReverseMap();
                    cfg.CreateMap<Product, ProductViewModel>().ReverseMap();
                    cfg.CreateMap<Rating, RatingViewModel>().ReverseMap();
                });

            Mapper = conig.CreateMapper();
        }
    }
}
