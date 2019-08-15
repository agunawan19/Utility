using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.RegistrationByConvention;
using Unity.Injection;
using UnityDemo.Interfaces;

namespace UnityDemo
{
    public class ContainerMagic
    {
        //public static void RegisterElements(IUnityContainer container)
        //{
        //    Dial dial = new Dial("Linear");
        //    container.RegisterInstance(dial);

        //    container.RegisterType<IBattery, Battery>();
        //    container.RegisterType<ITuner, Tuner>();

        //    var batteryType = typeof(IBattery);
        //    var tunerType = typeof(ITuner);
        //    container.RegisterType<IRadio, Radio>(new InjectionConstructor(batteryType, tunerType, typeof(string)));

        //    container.RegisterType<ISpeaker, CheapSpeaker>("Cheap");
        //    container.RegisterType<ISpeaker, PriceySpeaker>("Expensive");
        //}
        public static void RegisterElements(IUnityContainer container)
        {
            container.RegisterTypes(
                AllClasses.FromLoadedAssemblies(),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.ContainerControlled);

            container.RegisterType<ISpeaker, CheapSpeaker>("Cheap");
            container.RegisterType<ISpeaker, PriceySpeaker>("Expensive");

            container.RegisterType<Casing>(new InjectionConstructor("Plastic"));
        }
    }
}
