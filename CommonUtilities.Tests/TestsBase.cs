using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Moq;

namespace CommonUtilities.Tests
{
    public class TestsBase
    {
        public IUnityContainer Container { get; }

        public TestsBase()
        {
            Container = new UnityContainer();
            Container.RegisterInstance(typeof(Mock), new Mock<IUnityContainer>());
        }
    }
}
