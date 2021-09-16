using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Photo { get; set; }
        [Required]
        [MinLength(20)]
        public string Desc { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [DataType(DataType.Currency)]

        public decimal Offer_Price { get; set; }

        [DefaultValue(0)]
        public int Sell_Count { get; set; }

        [DefaultValue(false)]
        public bool Active { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Created_at { get; set; }
        public string Vendor_User_id { get; set; }
        [Required]
        public int Sub_Cat_Id { get; set; }
        [Required]
        public int Brand_Id { get; set; }

        [ForeignKey("Vendor_User_id")]
        public ApplicationUser Vendor { get; set; }

        [ForeignKey("Sub_Cat_Id")]
        public virtual Sub_Category Sub_Category { get; set; }

        [ForeignKey("Brand_Id")]
        public virtual Brand Brand { get; set; }

        public List<WishList> WishLists { get; set; }

        public List<Order_Product> Orders { get; set; }
        public virtual List<Rating> Ratings { get; set; }


    }
}
