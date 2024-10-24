using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPF.Tesetto.Word
{
    public partial class PageHost : UserControl
    {
        #region Dependency Properties

        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(BasePage), typeof(PageHost), new UIPropertyMetadata(CurrentPagePropertyChanged));

        #endregion Dependency Properties

        #region Constructor

        public PageHost()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Public Properties

        public BasePage CurrentPage
        {
            get { return (BasePage)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }

        #endregion Public Properties

        #region Property Changed Events

        private static void CurrentPagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newPageFrame = (d as PageHost).NewFrame;
            var oldPageFrame = (d as PageHost).OldFrame;

            var oldPageContent = newPageFrame.Content;

            newPageFrame.Content = null;
            oldPageFrame.Content = oldPageContent;

            if (oldPageContent is BasePage oldPage)
                oldPage.ShouldAnimateOut = true;

            newPageFrame.Content = e.NewValue;
        }

        #endregion Property Changed Events
    }
}