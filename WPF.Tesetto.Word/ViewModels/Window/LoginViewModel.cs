using PropertyChanged;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF.Tesetto.Word
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await Login(parameter));
        }

        public string Email { get; set; }
        public bool LoginIsRunning { get; set; }

        public ICommand LoginCommand { get; set; }

        public async Task Login(object parameter)
        {
            await RunCommand(() => LoginIsRunning, async () =>
            {
                await Task.Delay(2000);
                var email = Email;
                var password = (parameter as IHavePassword).SecurePassword.Unsecure();
            });
        }
    }
}