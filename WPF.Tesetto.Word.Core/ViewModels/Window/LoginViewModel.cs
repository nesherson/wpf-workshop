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
            GoToRegisterPageCommand = new RelayCommand(async () => await GoToRegisterPageAsync());
        }

        public string Email { get; set; }
        public bool LoginIsRunning { get; set; }

        public ICommand LoginCommand { get; }
        public ICommand GoToRegisterPageCommand { get; }
        public ICommand GoBackToLoginCommand { get; }

        public async Task LoginAsync(object parameter)
        {
            await RunCommand(() => LoginIsRunning, async () =>
            {
                await Task.Delay(1000);
                //var email = Email;
                //var password = (parameter as IHavePassword).SecurePassword.Unsecure();
                Ioc.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Chat);
            });
        }

        public Task GoToRegisterPageAsync()
        {
            Ioc.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Register);

            return Task.CompletedTask;
        }
    }
}