using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModels;

namespace ViewModelsTests
{
    [TestClass]
    public class WriteHelloWorldTests
    {
        [TestMethod]
        public void ActionTurnsTextIntoHelloWorld()
        {
            //arrange
            HelloWorldViewModel helloWorldViewModel = new HelloWorldViewModel(new CommandFactory());

            //act
            helloWorldViewModel.WriteHelloWorldCommand.Execute(this);

            //assert
            Assert.AreEqual("Hello World", helloWorldViewModel.Text);
        }
    }
}
