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
    public enum Order_Status{
        Delivered,
        Pending,
        Cancelled
    }

    public class Order
    {
        public int Id { get; set; }
        [DefaultValue(Order_Status.Pending)]
        public Order_Status Status { get; set; }
        public decimal Total_Price { get; set; }

        [Required]
        public string Address { get; set; }
        public DateTime Created_at { get; set; }
        [Required]
        public string User_Id { get; set; }

        public int Payment_Id { get; set; }

        [ForeignKey("User_Id")]
        public ApplicationUser User { get; set; }

        [ForeignKey("Payment_Id")]
        public Payment Payment { get; set; }

        public List<Order_Product> Products { get; set; }

    }
}
