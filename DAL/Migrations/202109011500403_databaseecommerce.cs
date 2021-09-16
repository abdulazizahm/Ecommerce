namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseecommerce : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Photo = c.String(nullable: false),
                        Desc = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Offer_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sell_Count = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Created_at = c.DateTime(nullable: false),
                        Vendor_User_id = c.String(maxLength: 128),
                        Sub_Cat_Id = c.Int(nullable: false),
                        Brand_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.Brand_Id, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.Vendor_User_id)
                .ForeignKey("dbo.Sub_Category", t => t.Sub_Cat_Id, cascadeDelete: true)
                .Index(t => t.Vendor_User_id)
                .Index(t => t.Sub_Cat_Id)
                .Index(t => t.Brand_Id);
            
            CreateTable(
                "dbo.Order_Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        Total_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Address = c.String(nullable: false),
                        Created_at = c.DateTime(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                        Payment_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Payments", t => t.Payment_Id, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Payment_Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Payment_Method = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(maxLength: 20),
                        LastName = c.String(maxLength: 20),
                        Address = c.String(),
                        Active = c.Boolean(nullable: false),
                        Created_at = c.DateTime(nullable: false),
                        Photo = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rate = c.Int(nullable: false),
                        Comment = c.String(),
                        Created_at = c.DateTime(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.WishLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.String(nullable: false, maxLength: 128),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Sub_Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Parent_Id = c.Int(),
                        Cat_Id = c.Int(nullable: false),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Main_Category", t => t.Cat_Id, cascadeDelete: true)
                .ForeignKey("dbo.Sub_Category", t => t.Parent_Id)
                .Index(t => t.Parent_Id)
                .Index(t => t.Cat_Id);
            
            CreateTable(
                "dbo.Main_Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Products", "Sub_Cat_Id", "dbo.Sub_Category");
            DropForeignKey("dbo.Sub_Category", "Parent_Id", "dbo.Sub_Category");
            DropForeignKey("dbo.Sub_Category", "Cat_Id", "dbo.Main_Category");
            DropForeignKey("dbo.Order_Product", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Order_Product", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.WishLists", "User_Id", "dbo.User");
            DropForeignKey("dbo.WishLists", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.Ratings", "User_Id", "dbo.User");
            DropForeignKey("dbo.Ratings", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "Vendor_User_id", "dbo.User");
            DropForeignKey("dbo.Orders", "User_Id", "dbo.User");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.Orders", "Payment_Id", "dbo.Payments");
            DropForeignKey("dbo.Products", "Brand_Id", "dbo.Brands");
            DropIndex("dbo.Role", "RoleNameIndex");
            DropIndex("dbo.Sub_Category", new[] { "Cat_Id" });
            DropIndex("dbo.Sub_Category", new[] { "Parent_Id" });
            DropIndex("dbo.WishLists", new[] { "Product_Id" });
            DropIndex("dbo.WishLists", new[] { "User_Id" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.Ratings", new[] { "Product_Id" });
            DropIndex("dbo.Ratings", new[] { "User_Id" });
            DropIndex("dbo.UserLogin", new[] { "UserId" });
            DropIndex("dbo.UserClaim", new[] { "UserId" });
            DropIndex("dbo.User", "UserNameIndex");
            DropIndex("dbo.User", new[] { "Email" });
            DropIndex("dbo.Orders", new[] { "Payment_Id" });
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.Order_Product", new[] { "Product_Id" });
            DropIndex("dbo.Order_Product", new[] { "Order_Id" });
            DropIndex("dbo.Products", new[] { "Brand_Id" });
            DropIndex("dbo.Products", new[] { "Sub_Cat_Id" });
            DropIndex("dbo.Products", new[] { "Vendor_User_id" });
            DropTable("dbo.Role");
            DropTable("dbo.Main_Category");
            DropTable("dbo.Sub_Category");
            DropTable("dbo.WishLists");
            DropTable("dbo.UserRole");
            DropTable("dbo.Ratings");
            DropTable("dbo.UserLogin");
            DropTable("dbo.UserClaim");
            DropTable("dbo.User");
            DropTable("dbo.Payments");
            DropTable("dbo.Orders");
            DropTable("dbo.Order_Product");
            DropTable("dbo.Products");
            DropTable("dbo.Brands");
            DropTable("dbo.Abouts");
        }
    }
}
