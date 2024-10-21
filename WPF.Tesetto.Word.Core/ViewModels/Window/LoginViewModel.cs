using PropertyChanged;
using System.Windows.Input;

namespace WPF.Tesetto.Word.Core
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await LoginAsync(parameter));
            RegisterCommand = new RelayCommand(async () => await RegisterAsync());
        }

        public string Email { get; set; }
        public bool LoginIsRunning { get; set; }

        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public async Task LoginAsync(object parameter)
        {
            await RunCommand(() => LoginIsRunning, async () =>
            {
                await Task.Delay(2000);
                var email = Email;
                var password = (parameter as IHavePassword).SecurePassword.Unsecure();
            });
        }

        public async Task RegisterAsync()
        {
            //((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Register;
        }
    }
}