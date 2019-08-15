using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Resolution;
using UnityDemo;
using UnityDemo.Interfaces;

namespace UnityDemoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            ContainerMagic.RegisterElements(container);

            IBattery battery = container.Resolve<IBattery>();
            Console.WriteLine(battery.SerialNumber());

            Dial dial = container.Resolve<Dial>(new ParameterOverride("typeOfDial", "linear"));
            Console.WriteLine(dial.DialType());

            ITuner tuner = container.Resolve<ITuner>();
            Console.WriteLine(tuner.SerialNumber());
            IRadio radio = container.Resolve<IRadio>(new ParameterOverride("radioBattery", battery),
                new ParameterOverride("radioTuner", tuner),
                new ParameterOverride("radioName", "BrokenRadio"));
            radio.Start();

            ISpeaker cheapSpeaker = container.Resolve<ISpeaker>("Cheap");
            ISpeaker priceySpeaker = container.Resolve<ISpeaker>("Expensive");
            cheapSpeaker.Start();
            priceySpeaker.Start();

            ICasing casing = container.Resolve<ICasing>();
            Console.WriteLine(casing.TypeOfMaterial());

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
