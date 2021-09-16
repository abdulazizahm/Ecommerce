using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class Item
    {
        public ProductViewModel Product
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }

    }
}
