using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ciaran McMahon
//402914
//Assessment2
//Customer Class

namespace Assessment2
{
    class Customer
    {
        
        private string custname;
        private string custaddress;
        private int custref;
        
        public string CustName
        {
            get { return custname; }
            set
            {
                try
                {
                    if (!String.IsNullOrEmpty(value)) 
                    { 
                        custname = value;                        
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
        
        public string CustAddress
        {
            get { return custaddress; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    custaddress = value;                 
                }
                else
                {
                    throw new Exception("Please enter your address");
                }
            }
        }

        public int CustRef
        {
            get { return custref; }
            set
            {
      
                if (custref >= 0)
                {
                    custref = value;
                }
                else
                {
                    throw new Exception("Please enter a reference number");                   
                }
            }
        }
        
        List<Bookings> Bookings = new List<Bookings>();
        
    }
}
