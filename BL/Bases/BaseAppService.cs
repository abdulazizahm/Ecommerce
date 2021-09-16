using AutoMapper;
using BL.Configurations;
using BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Bases
{
    public class BaseAppService
    {
        #region Props
        protected IUnitOfWork TheUnitOfWork;
        protected readonly IMapper Mapper = MapperConfig.Mapper;
        #endregion

        #region CTOR

        public BaseAppService()
        {
            TheUnitOfWork = new UnitOfWork();
        }

        #endregion

        #region Methods
        void Dispose()
        {
            TheUnitOfWork.Dispose();
        }

        #endregion


    }
}
