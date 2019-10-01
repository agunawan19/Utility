using Ninject.Modules;
using Models;

namespace DependencyInjectionDemo
{
    public class DI : NinjectModule
    {
        public override void Load()
        {
            Bind<ICustomer>().To<RetailCustomer>();
            Bind<ICustomer>().To<WholeSaleCustomer>();
        }
    }
}
