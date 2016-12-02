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
    //For only once instance of customer at a time
    class CustomerSingleton
    {
        //List of customers
        public List<Customer> listofcustomers = new List<Customer>();
              
        private static CustomerSingleton instance;
                
        private static CustomerSingleton Instance()
    {
            if (instance == null)
            {
                instance = new CustomerSingleton();
            }
            return instance;
    }
    }

}
