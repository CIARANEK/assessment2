using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ciaran McMahon
//40291478
//Assessment 2
//Bookings Class

namespace Assessment2
{
    class Bookings
    {
        //Declare private variables
        private string arrive;
        private string depart;
        private int bookref;
        private int breakna;
        private int breakveg;
        private int breaknut;
        private int evena;
        private int eveveg;
        private int evenut;
        private string hirestart;
        private string hireend;
        private string drivername;

        //Get/Set for all variables, with validation and error messages
        public string Arrive
        {
            get { return arrive; }
            set
            {
                try
                {
                    if (!String.IsNullOrEmpty(value))
                    {
                        arrive = value;
                    }
                    else
                    {
                        throw new Exception("Please enter arrive valid arrival date");
                    }
                }
                catch(FormatException)
                {
                    throw new ArgumentException("Please enter your arrival date");
                }
            }
        }

        public string Depart
        {
            get { return depart; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    depart = value;
                }
                else
                {
                    throw new Exception("Please enter a valid departure date");
                }
            }
        }
            public int BookRef
            {
                get { return bookref; }
                set
                {
                    if (bookref >= 0)
                    {
                        bookref = value;
                    }
                    else
                    {
                        throw new Exception("Please enter a valid reference number");
                    }
                }
            }
        public int BreakNA
            {
                get { return breakna; }
                set
                {
                    if (breakna <= 0 && breakna >=5)
                    {
                        throw new Exception("Please enter a number between 0 and 4");
                    }
                    else
                    {
                        breakna = value;
                    }
                }
            }
        public int BreakVeg
        {
            get { return breakveg; }
            set
            {
                if (breakveg <= 0 && breakveg >= 5)
                {
                    throw new Exception("Please enter a number between 0 and 4");
                }
                else
                {
                    breakveg = value;
                }
            }
        }
        public int BreakNut
        {
            get { return breaknut; }
            set
            {
                if (breaknut <= 0 && breaknut >= 5)
                {
                    throw new Exception("Please enter a number between 0 and 4");
                }
                else
                {
                    breaknut = value;
                }
            }
        }
        public int EveNA
        {
            get { return evena; }
            set
            {
                if (evena <= 0 && evena >= 5)
                {
                    throw new Exception("Please enter a number between 0 and 4");
                }
                else
                {
                    evena = value;
                }
            }
    }
        public int EveVeg
        {
            get { return eveveg; }
            set
            {
                if (eveveg <= 0 && eveveg >= 5)
                {
                    throw new Exception("Please enter a number between 0 and 4");
                }
                else
                {
                    eveveg = value;
                }
            }
        }
        public int EveNut
        {
            get { return evenut; }
            set
            {
                if (evenut <= 0 && evenut >= 5)
                {
                    throw new Exception("Please enter a number between 0 and 4");
                }
                else
                {
                    evenut = value;
                }
            }
        }

        public string HireStart
        {
            get { return hirestart; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    hirestart = value;
                }
                else
                {
                    throw new Exception("Please enter a hire start date");
                }
            }
        }
        public string HireEnd
        {
            get { return hireend; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    hireend = value;
                }
                else
                {
                    throw new Exception("Please enter a hire end date");
                }
            }
        }
        public string DriverName
        {
            get { return drivername; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    drivername = value;
                }
                else
                {
                    throw new Exception("Please enter a valid name");
                }
            }
        }

        //list of guests
        public List<Guests> listofguests = new List<Guests>();      
    }
    
    
}
