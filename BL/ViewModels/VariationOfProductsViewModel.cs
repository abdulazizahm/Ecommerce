using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
   public class VariationOfProductsViewModel
    {
     public List<ProductViewModel> ProductViewModels { set; get; }
        public List<AdminDisplayUserViewModel> vendors { set; get; }

    }
}
