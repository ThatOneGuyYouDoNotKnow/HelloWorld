using DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DependencyInjectionTests.LocatorTests
{
    [TestClass]
    public class RegisterSingletonTests : LocatorTestBase
    {
        [TestMethod]
        public void GetTwoInstances_InstancesAreDifferent()
        {
            //arrange
            Locator.RegisterSingleton<ITest, Test>();

            //act
            ITest instance1 = Locator.GetInstance<ITest>();
            ITest instance2 = Locator.GetInstance<ITest>();

            //assert
            Assert.AreSame(instance1, instance2);
        }

        private interface ITest
        {
        }

        private class Test : ITest
        {
        }
    }
}
