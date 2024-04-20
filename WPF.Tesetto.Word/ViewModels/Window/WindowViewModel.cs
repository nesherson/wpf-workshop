using PropertyChanged;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF.Tesetto.Word
{
    [AddINotifyPropertyChangedInterface]
    public class WindowViewModel : BaseViewModel
    {
        private Window _window;
        private int _outerMarginSize = 10;
        private int _windowRadius = 10;
        private WindowDockPosition _dockPosition = WindowDockPosition.Undocked;

        public WindowViewModel(Window window)
        {
            _window = window;

            OuterMarginSize = 10;

            MinimizeCommand = new RelayCommand(Minimize);
            MaximizeCommand = new RelayCommand(Maximize);
            CloseCommand = new RelayCommand(Close);
            MenuCommand = new RelayCommand(Menu);

            _window.StateChanged += Window_StateChanged;

            var windowResizer = new WindowResizer(_window);
        }

        public double WindowMinimumWidth { get; set; } = 820;
        public double WindowMinimumHeight { get; set; } = 560;
        public int ResizeBorder => Borderless ? 0 : 6;
        public bool Borderless { get { return (_window.WindowState == WindowState.Maximized || _dockPosition != WindowDockPosition.Undocked); } }

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
        public Thickness InnerContentPadding { get; set; } = new(0);
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

        public ICommand MenuCommand { get; set; }
        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }


        private void Window_StateChanged(object? sender, System.EventArgs e)
        {
            OnPropertyChanged(nameof(Borderless));
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
