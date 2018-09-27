using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DependencyInjectionTests.LocatorTests
{
    [TestClass]
    public class RegisterScopedTests : LocatorTestBase
    {
        [TestMethod]
        [Ignore]
        public void GetTwoInstancesInDifferentScope_InstancesAreDifferent()
        {
            //todo
        }

        private interface ITest
        {
        }

        private class Test : ITest
        {
        }
    }
}
