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
            GoBackToLoginCommand = new RelayCommand(async () => await GoBackToLoginAsync());
        }

        public string Email { get; set; }
        public bool LoginIsRunning { get; set; }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand GoBackToLoginCommand { get; }

        public async Task LoginAsync(object parameter)
        {
            await RunCommand(() => LoginIsRunning, async () =>
            {
                await Task.Delay(2000);
                var email = Email;
                var password = (parameter as IHavePassword).SecurePassword.Unsecure();
            });
        }

        public Task RegisterAsync()
        {
            Ioc.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Register;

            return Task.CompletedTask;
        }

        public Task GoBackToLoginAsync()
        {
            Ioc.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Login;

            return Task.CompletedTask;
        }
    }
}