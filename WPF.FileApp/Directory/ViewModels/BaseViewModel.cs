using PropertyChanged;
using System.ComponentModel;

namespace WPF.FileApp
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged = (e, sender) => { };
    }
}