using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Models
{
    public class WholeSaleCustomer : ICustomer
    {
        public void GetDetails()
        {
            const string text = "WholeSale customers";
            Console.WriteLine(text);
        }
    }
}
