using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WPF.Workshop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var driveName in Directory.GetLogicalDrives())
            {
                var treeViewItem = new TreeViewItem();
                treeViewItem.Header = driveName;
                FolderView.Items.Add(treeViewItem);
            }
        }
    }
}