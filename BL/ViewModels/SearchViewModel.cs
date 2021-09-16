using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class SearchViewModel
    {
        [Required]
        public int SubCatId { set; get; }
        [Required]
        public string SearchText { get; set; }
    }
}
