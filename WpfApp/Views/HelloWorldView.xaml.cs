using ViewModels;

namespace Views
{
    public partial class HelloWorldView
    {
        public HelloWorldView()
        {
            InitializeComponent();
            DataContext = new HelloWorldViewModel();
        }
    }
}
