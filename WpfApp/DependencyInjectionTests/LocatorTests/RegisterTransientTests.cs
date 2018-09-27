using DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DependencyInjectionTests.LocatorTests
{
    [TestClass]
    public class RegisterTransientTests : LocatorTestBase
    {
        [TestMethod]
        public void GetTwoInstances_InstancesAreDifferent()
        {
            //arrange
            Locator.RegisterTransient<ITest, Test>();

            //act
            ITest instance1 = Locator.GetInstance<ITest>();
            ITest instance2 = Locator.GetInstance<ITest>();

            //assert
            Assert.AreNotSame(instance1, instance2);
        }

        private interface ITest
        {
        }

        private class Test : ITest
        {
        }
    }
}
