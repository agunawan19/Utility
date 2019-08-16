using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;
using CarFactory;

namespace CarConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DependencyInjectionSample();

            DependencyInjectionWithUnitySample();

            Console.ReadLine();
        }

        private static void DependencyInjectionSample()
        {
            Driver driver = new Driver(new BMW());

            driver.RunCar();
        }

        private static void DependencyInjectionWithUnitySample()
        {
            var container = new UnityContainer();
            container.RegisterType<ICar, BMW>();
            container.RegisterType<ICar, Audi>("LuxuryCar");

            // Registers Driver type            
            container.RegisterType<Driver>("LuxuryCarDriver",
                new InjectionConstructor(container.Resolve<ICar>("LuxuryCar")));

            Driver driver1 = container.Resolve<Driver>(); // injects BMW
            driver1.RunCar();

            Driver driver2 = container.Resolve<Driver>("LuxuryCarDriver");// injects Audi
            driver2.RunCar();
        }
    }
}
