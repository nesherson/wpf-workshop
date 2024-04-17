using PropertyChanged;
using System.Windows;

namespace WPF.Tesetto.Word
{
    [AddINotifyPropertyChangedInterface]
    public class WindowViewModel : BaseViewModel
    {
        private Window _window;
        private int _outerMarginSize;
        private int _windowRadius;
        public WindowViewModel(Window window)
        {
            _window = window;

            _window.StateChanged += Window_StateChanged;
        }

        private void Window_StateChanged(object? sender, System.EventArgs e)
        {
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(OuterMarginSizeThickness));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowCornerRadius));
        }

        public int ResizeBorder { get; set; } = 6;

        public int OuterMarginSize 
        { 
            get
            {
                return _window.WindowState == WindowState.Maximized ? 0 : _outerMarginSize;
            }
            set
            {
                _outerMarginSize = value;
            }
        }

        public int WindowRadius
        {
            get
            {
                return _window.WindowState == WindowState.Maximized ? 0 : _windowRadius;
            }
            set
            {
                _windowRadius = value;
            }
        }

        public Thickness ResizeBorderThickness => new(ResizeBorder + OuterMarginSize);

        public Thickness OuterMarginSizeThickness => new(OuterMarginSize);

        public CornerRadius WindowCornerRadius => new(WindowRadius);

    }
}
