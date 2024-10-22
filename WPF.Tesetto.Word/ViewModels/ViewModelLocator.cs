using WPF.Tesetto.Word.Core;

namespace WPF.Tesetto.Word
{
    public class ViewModelLocator
    {
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();
        public static ApplicationViewModel ApplicationViewModel => Ioc.Get<ApplicationViewModel>();
    }
}