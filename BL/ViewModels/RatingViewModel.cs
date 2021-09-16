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
    public class RatingViewModel
    {
        public int Id { get; set; }
        [Required]
        public int Rate { get; set; }
        public string Comment { get; set; }
        public DateTime Created_at { get; set; }
        public string User_Id { get; set; }
        [Required]
        public int Product_Id { get; set; }


        [ForeignKey("User_Id")]
        public virtual ApplicationUser User { get; set; }
        [ForeignKey("Product_Id")]
        public virtual Product Product { get; set; }

    }
}
