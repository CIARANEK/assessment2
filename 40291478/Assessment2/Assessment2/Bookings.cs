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
        private DateTime arrive;
        private DateTime depart;
        private int bookref;
        private int noofguest;
        private int breakna;
        private int breakveg;
        private int breaknut;
        private int evena;
        private int eveveg;
        private int evenut;
        private DateTime hirestart;
        private DateTime hireend;
        private string drivername;

        //Get/Set for all variables, with validation and error messages
        public DateTime Arrive
        {
            get { return arrive; }
            set
            {
                try
                {
                    if (arrive == null)
                    {
                       throw new Exception("Please enter arrive valid arrival date");
                    }
                    else
                    {
                        arrive = value;
                    }
                }
                catch(FormatException)
                {
                    throw new ArgumentException("Please enter your arrival date");
                }
            }
        }

        public DateTime Depart
        {
            get { return depart; }
            set
            {
                if (depart == null)
                {
                    throw new Exception("Please enter a valid departure date");
                }
                else
                {
                    depart = value;
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
            public int NoOfGuest
            {       //Gets the number of guests                
                    get { return noofguest; }
                    set
                    {
                        //Sets the number of guests if it is less than 5
                    if (noofguest <= 0 && noofguest >=5)
                    {
                        throw new Exception("Please enter a valid number of guests. Max of 4");
                    }
                    else
                    {
                        noofguest = value;
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

        public DateTime HireStart
        {
            get { return hirestart; }
            set
            {
                if (hirestart == null)
                {
                    throw new Exception("Please enter a hire start date");
                }
                else
                {
                    hirestart = value;
                }
            }
        }
        public DateTime HireEnd
        {
            get { return hireend; }
            set
            {
                if (hireend == null)
                {
                    throw new Exception("Please enter a hire end date");
                }
                else
                {
                    hireend = value;
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
