using PropertyChanged;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

            OuterMarginSize = 10;

            MinimizeCommand = new RelayCommand(Minimize);
            MaximizeCommand = new RelayCommand(Maximize);
            CloseCommand = new RelayCommand(Close);
            MenuCommand = new RelayCommand(Menu);

            _window.StateChanged += Window_StateChanged;
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

        public int TitleHeight { get; set; } = 40;

        public GridLength TitleHeightGridLength => new(TitleHeight + ResizeBorder);

        public ICommand MenuCommand { get; set; }
        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        private void Window_StateChanged(object? sender, System.EventArgs e)
        {
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(OuterMarginSizeThickness));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowCornerRadius));
        }

        private void Minimize()
        {
            _window.WindowState = WindowState.Minimized;
        }

        private void Maximize()
        {
            _window.WindowState ^= WindowState.Maximized;
        }

        private void Close()
        {
            _window.Close();
        }

        private void Menu()
        {
            SystemCommands.ShowSystemMenu(_window, GetMousePosition());
        }

        private Point GetMousePosition()
        {
            var position = Mouse.GetPosition(_window);

            return new Point(position.X + _window.Left, position.Y + _window.Top);
        }
    }
}
