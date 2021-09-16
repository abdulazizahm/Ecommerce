using BL.AppServices;
using DAL.Model;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    public class AccountRepository//: BaseRepository<ApplicationUserIdentity>
    {
        readonly ApplicationUserManager manager;

        public AccountRepository(DbContext db)
        {
            manager = new ApplicationUserManager(db);
        }


        public ApplicationUser Find(string username, string password)
        {
            return manager.Find(username, password);
        }
        

        public ApplicationUser Find(string username)
        {
            return manager.FindByName(username);
        }
        
        public IQueryable<ApplicationUser> Where(Expression<Func<ApplicationUser, bool>> filter)
        {
            return manager.Users.Where(filter);
        }

        public IdentityResult Register (ApplicationUser user)
        {
            user.Created_at = DateTime.Now;
            return manager.Create(user, user.PasswordHash);
        }



        public IdentityResult AssignToRole (string userId, string roleName)
        {
            return manager.AddToRole(userId, roleName);
        }

        
        public IdentityResult RemoveFromRole(string userId, string roleName)
        {
            return manager.RemoveFromRole(userId, roleName);
        }

        public bool IsInRole(string user_id, Role_Name role)
        {
            return manager.IsInRole(user_id, role.ToString());
        }

        public ApplicationUser FindByEmailAndPassword(string Email, string Password)
        {
            var userForEmail = manager.FindByEmailAsync(Email).Result;
            if (userForEmail != null)
            {
                var username = userForEmail.UserName;
                return manager.FindAsync(username, Password).Result;
            }
            return null;
        }

        public bool HasEmail(string email)
        {
            return manager.Users.Any(u => u.Email == email);
        }

        public List<ApplicationUser> GetAllUsersByRole(Role_Name role)
        {
            List<ApplicationUser> retval = new List<ApplicationUser>();
            var allusers = manager.Users.ToList();
            foreach (var user in allusers)
            {
                if (IsInRole(user.Id, role))
                {
                    retval.Add(user);
                }
            }
            return retval;
        }

    }
}
