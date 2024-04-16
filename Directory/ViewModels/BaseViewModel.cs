using PropertyChanged;
using System.ComponentModel;

namespace WPF.Workshop
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged = (e, sender) => { };
    }
}
