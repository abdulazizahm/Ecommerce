using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Sub_Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? Parent_Id { get; set; }

        public int Cat_Id { get; set; }
        public string Photo { get; set; }
        [Display(Name = "Main Category")]
        [ForeignKey("Cat_Id")]
        public Main_Category Main_Category { get; set; }
        [Display(Name = "Sub Category")]
        [ForeignKey("Parent_Id")]
        public Sub_Category Parent { get; set; }

        public List<Product> Products { get; set; }
    }
}
