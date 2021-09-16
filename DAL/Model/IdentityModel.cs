using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DAL.Model
{
    public enum Role_Name {Admin, Vendor, User }

    public class ApplicationUser: IdentityUser
    {

        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
        public DateTime Created_at { get; set; }
        public string Photo { get; set; }

        public List<Product> Products { get; set; }

        public List<WishList> WishLists { get; set; }

        public List<Order> Orders { get; set; }

        public List<Rating> Ratings { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //DBsets
        public DbSet<Brand> Brands { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Main_Category> Main_Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Product> Order_Products { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Sub_Category> Sub_Categories { get; set; }
        public DbSet<WishList> WishLists { get; set; }



        public ApplicationDbContext(): base("CS")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // This needs to go before the other rules!

            modelBuilder.Entity<ApplicationUser>().ToTable("User");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");

            modelBuilder.Entity<ApplicationUser>()
                .HasIndex(u => u.Email)
                .IsUnique();

        }

        //public System.Data.Entity.DbSet<BL.ViewModels.ProductViewModel> ProductViewModels { get; set; }
    }

    public class ApplicationUserStore: UserStore<ApplicationUser>
    {
        
        public ApplicationUserStore(): base(new ApplicationDbContext())
        {

        }

        public ApplicationUserStore(DbContext db): base(db)
        {

        }
    }

    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager():base(new ApplicationUserStore())
        {
        }

        public ApplicationUserManager(DbContext db):base(new ApplicationUserStore(db))
        {
        }
    }

    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(): base(new RoleStore<IdentityRole>(new ApplicationDbContext()))
        {
        }

        public ApplicationRoleManager(DbContext db): base(new RoleStore<IdentityRole>(db))
        {
        }
    }

}
