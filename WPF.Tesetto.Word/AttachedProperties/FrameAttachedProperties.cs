using System.Windows;
using System.Windows.Controls;

namespace WPF.Tesetto.Word
{
    public class NoFrameHistoryProperty : BaseAttachedProperty<NoFrameHistoryProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var frame = (sender as Frame);

            frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            frame.Navigated += (o, args) =>
            {
                (o as Frame).NavigationService.RemoveBackEntry();
            };
        }
    }
}