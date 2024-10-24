using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPF.Tesetto.Word
{
    public class BasePage : Page
    {
        #region Constructor

        public BasePage()
        {
            if (PageLoadAnimation != PageAnimation.None)
                Visibility = Visibility.Collapsed;

            Loaded += BasePage_Loaded;
        }

        #endregion Constructor

        #region Public Propeties

        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;
        public float SlideSeconds { get; set; } = 0.4f;
        public bool ShouldAnimateOut { get; set; }

        #endregion Public Propeties

        #region Animate In/Out

        public async Task AnimateInAsync()
        {
            if (PageLoadAnimation == PageAnimation.None)
                return;

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInFromRightAsync(SlideSeconds);
                    break;
            }
        }

        public async Task AnimateOutAsync()
        {
            if (PageUnloadAnimation == PageAnimation.None)
                return;

            switch (PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:
                    await this.SlideAndFadeOutToLeftAsync(SlideSeconds);
                    break;
            }
        }

        private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ShouldAnimateOut)
            {
                await AnimateOutAsync();
                ShouldAnimateOut = false;
            }
            else
            {
                await AnimateInAsync();
            }
        }

        #endregion Animate In/Out
    }

    public class BasePage<TViewModel> : BasePage
        where TViewModel : BaseViewModel, new()
    {
        #region Private Members

        private TViewModel _viewModel;

        #endregion Private Members

        #region Constructor

        public BasePage() : base()
        {
            ViewModel = new TViewModel();
        }

        #endregion Constructor

        #region Public Properties

        public TViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                if (_viewModel == value)
                    return;

                _viewModel = value;
                DataContext = _viewModel;
            }
        }

        #endregion Public Properties
    }
}