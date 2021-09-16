using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public enum Payment_Method
    {
        Visa,
        Cash,
        PayPal
    }

    public class Payment
    {
        public int Id { get; set; }

        [DefaultValue(Payment_Method.Cash)]
        public Payment_Method Payment_Method { get; set; }

        [DefaultValue(false)]
        public bool Status { get; set; }

        public List<Order> Orders { get; set; }
    }
}
