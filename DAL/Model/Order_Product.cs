using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{


    
    public class Order_Product
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("Order")]
        public int Order_Id { get; set; }
        [ForeignKey("Product")]
        public int Product_Id { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }



    }
}
