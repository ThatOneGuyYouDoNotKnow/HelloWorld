using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModels;

namespace ViewModelsTests
{
    [TestClass]
    public class WriteHelloWorldTests
    {
        [TestMethod]
        [Ignore]
        public void ActionTurnsTextIntoHelloWorld()
        {
            //arrange
            HelloWorldViewModel helloWorldViewModel = new HelloWorldViewModel();

            //act
            helloWorldViewModel.WriteHelloWorldCommand.Execute(null);

            //assert
            Assert.AreEqual("Hello World", helloWorldViewModel.Text);
        }
    }
}
