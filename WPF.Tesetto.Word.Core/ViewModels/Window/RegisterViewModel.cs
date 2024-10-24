using PropertyChanged;
using System.Windows.Input;

namespace WPF.Tesetto.Word.Core
{
    [AddINotifyPropertyChangedInterface]
    public class RegisterViewModel : BaseViewModel
    {
        public RegisterViewModel()
        {
            RegisterCommand = new RelayParameterizedCommand(async (parameter) => await RegisterAsync(parameter));
            GoToLoginPageCommand = new RelayCommand(async () => await GoToLoginPageAsync());
        }

        public string Email { get; set; }
        public bool RegisterIsRunning { get; set; }

        public ICommand RegisterCommand { get; }
        public ICommand GoToLoginPageCommand { get; }

        public async Task RegisterAsync(object parameter)
        {
            await RunCommand(() => RegisterIsRunning, async () =>
            {
                await Task.Delay(2000);
            });
        }

        public Task GoToLoginPageAsync()
        {
            Ioc.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Login;

            return Task.CompletedTask;
        }
    }
}