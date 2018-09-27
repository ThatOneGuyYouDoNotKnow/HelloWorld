using DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DependencyInjectionTests.LocatorTests
{
    [TestClass]
    public abstract class LocatorTestBase
    {
        [TestInitialize]
        public void TestInitialize()
        {
            Locator.ResetContainer();
            OnInitialize();
        }

        protected virtual void OnInitialize()
        {
        }

        [TestCleanup]
        public void TestCleanup()
        {
            OnCleanup();
            Locator.ResetContainer();
        }

        protected virtual void OnCleanup()
        {
        }
    }
}
