using DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
  public  class ProductViewModel:IComparable
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
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

        public int Sell_Count { get; set; }

        public DateTime Created_at = DateTime.Now;

        public string Vendor_User_id { get; set; }
        [Required]
        public int Sub_Cat_Id { get; set; }
        [Required]
        public int Brand_Id { get; set; }


        //public virtual ApplicationUser Vendor { get; set; }
        public string Vendor_Name { get; set; }

        public Sub_Category Sub_Category { get; set; }


        public BrandViewModel Brand { get; set; }
        public virtual List<Rating> Ratings { get; set; }
        public List<WishList> wishLists { set; get; }

        public int CompareTo(object obj)
        {
            ProductViewModel prod = obj as ProductViewModel;
            if (prod == null)
            {
                return 0;
            }
            else
            {
                if (prod.Sell_Count > this.Sell_Count)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
           
        }
    }
}
