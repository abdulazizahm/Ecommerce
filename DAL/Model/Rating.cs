using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Rating
    {
        public int Id { get; set; }
        [Required]
        public int Rate { get; set; }
        public string Comment { get; set; }
        public DateTime Created_at { get; set; }

        [Required]
        public string User_Id { get; set; }
        [Required]
        public int Product_Id { get; set; }


        [ForeignKey("User_Id")]
        public ApplicationUser User { get; set; }
        [ForeignKey("Product_Id")]
        public Product Product { get; set; }

    }
}
