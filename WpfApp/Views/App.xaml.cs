using System;
using System.Windows;
using DependencyInjection;

namespace Views
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Locator.RegisterPackages();

            if (Current == null)
            {
                throw new ApplicationException("The application has not been setup properly.");
            }

            Current.MainWindow = Locator.GetInstance<HelloWorldView>();
            Current.MainWindow.Show();
        }
    }
}
