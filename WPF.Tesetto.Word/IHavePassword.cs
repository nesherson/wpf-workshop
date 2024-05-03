using System.Security;

namespace WPF.Tesetto.Word
{
    public interface IHavePassword
    {
        public SecureString SecurePassword { get; }
    }
}