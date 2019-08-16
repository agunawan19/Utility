using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactory
{
    public class Driver
    {
        private ICar Car { get; set; } = null;

        public Driver(ICar car)
        {
            Car = car;
        }

        public void RunCar()
        {
            Console.WriteLine($"Running {Car.GetType().Name} - {Car.Run()} mile ");
        }
    }
}
