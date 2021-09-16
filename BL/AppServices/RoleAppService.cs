using BL.Bases;
using BL.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class RoleAppService : BaseAppService
    {
        public IdentityResult Create(string role)
        {
            return TheUnitOfWork.Role.Create(role);
        }
    }
}
