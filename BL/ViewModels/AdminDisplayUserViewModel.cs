using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class AdminDisplayUserViewModel
    {
        private string firstName;
        private string lastName;
        public string FirstName {
            get
            {
                return firstName;
            }
            set 
            {
                //  firstName = value.ToUpper()[0] + value.Substring(1);
                firstName = value;
            }
        }
        public string LastName 
        {
            get
            {
                return lastName;
            }
            set
            {
                // lastName = value.ToUpper()[0] + value.Substring(1);
                lastName = value;
            }
        }
        public string ID { get; set; }
        public string Email { get; set; }

public string Photo { set; get; }
    }
}
