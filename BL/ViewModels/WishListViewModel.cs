using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class WishListViewModel
    {
        public int Id { get; set; }
       
        public string User_Id { get; set; }
    
        public int Product_Id { get; set; }

        public string user_Name { get; set; }
        public ProductViewModel product { get; set; }


    }
}
