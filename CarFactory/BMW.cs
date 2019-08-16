using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactory
{
    public class BMW : ICar
    {
        public int Miles { get; set; } = 0;

        public int Run()
        {
            return ++Miles;
        }
    }
}
