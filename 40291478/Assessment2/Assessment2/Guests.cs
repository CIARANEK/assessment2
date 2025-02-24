﻿using System;
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
        //Declare private variables
        private string guestname;
        private string passportnum;
        private int age;

        //Get/Set for all variables, with validation and error messages
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
                        throw new Exception("Please enter a valid name");
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
                if (age >= 0 && age <= 101)
                {
                    age = value;
                }
                else
                {
                    throw new Exception("Please enter your age");
                }
            }
        }
    }
}

