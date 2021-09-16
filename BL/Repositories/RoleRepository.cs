using DAL.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    public class RoleRepository
    {
        readonly ApplicationRoleManager manager;

        public RoleRepository(DbContext db)
        {
            manager = new ApplicationRoleManager(db);
        }


        public IdentityResult Create(string role)
        {
            return manager.CreateAsync(new IdentityRole(role)).Result;
        }

    }
}
