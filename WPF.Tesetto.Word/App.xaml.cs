using System.Windows;
using WPF.Tesetto.Word.Core;

namespace WPF.Tesetto.Word
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Ioc.Setup();

            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }
    }
}