namespace WPF.Tesetto.Word.Core
{
    public static class ViewModelLocator
    {
        public static ApplicationViewModel ApplicationViewModel => Ioc.Get<ApplicationViewModel>();
    }
}