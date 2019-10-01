using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Factory
{
    public class Admin
    {
        private readonly ICustomer cust;

        public Admin(ICustomer custIOC)
        {
            cust = custIOC;
        }

        public void GetCustomerDetails()
        {
            cust.GetDetails();
        }
    }
}
