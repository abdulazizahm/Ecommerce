using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Brand
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
       
        public string Photo { get; set; }


        public List<Product> Products { get; set; }
    }
}
