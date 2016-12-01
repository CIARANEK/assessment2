using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ciaran McMahon
//402914
//Assessment2
//Customer Singleton Class
namespace Assessment2
{
    class CustomerSingleton
    {
        //List of customers
        public List<Customer> listofcustomers = new List<Customer>();
              
        private static CustomerSingleton instance;
                
        public static CustomerSingleton Instance()
    {
            if (instance == null)
            {
                instance = new CustomerSingleton();
            }
            return instance;
    }
    }

}
