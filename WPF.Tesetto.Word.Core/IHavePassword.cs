using System.Security;

namespace WPF.Tesetto.Word.Core
{
    public interface IHavePassword
    {
        public SecureString SecurePassword { get; }
    }
}