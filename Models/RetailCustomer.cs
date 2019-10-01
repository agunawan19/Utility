using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RetailCustomer : ICustomer
    {
        public void GetDetails()
        {
            const string text = "Retail customers";
            Console.WriteLine(text);
        }
    }
}
