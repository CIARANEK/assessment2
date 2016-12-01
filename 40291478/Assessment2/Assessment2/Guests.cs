using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ciaran McMahon
//40291478
//Assessment 2
//Guest Class

namespace Assessment2
{
    class Guests
    {
        private string guestname;
        private string passportnum;
        private int age;

        public string Guestname
        {
            get { return guestname; }
            set
            {
                try
                {
                    if (!String.IsNullOrEmpty(value))
                    {
                        guestname = value;
                    }
                    else
                    {
                        throw new Exception("Please enter a valid First name");
                    }
                }
                catch (FormatException)
                {
                    throw new ArgumentException("Please enter your name");
                }
            }
        }
        public string PassportNum
        {
            get { return passportnum; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    passportnum = value;
                }
                else
                {
                    throw new Exception("Please enter a valid passport number");
                }
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (age >= 18)
                {
                    age = value;
                }
                else
                {
                    throw new Exception("Please enter a legal age");
                }
            }
        }
    }
}

