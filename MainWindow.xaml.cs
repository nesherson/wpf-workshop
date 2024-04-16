using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                treeViewItem.Tag = driveName;

                treeViewItem.Items.Add(null);

                treeViewItem.Expanded += Folder_Expanded;


                FolderView.Items.Add(treeViewItem);
            }
        }

        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            var item = sender as TreeViewItem;

            if (item.Items.Count != 1 || item.Items[0] != null)
                return;

            item.Items.Clear();

            var fullPath = item.Tag as string;
            var directories = new List<string>();
            var files = new List<string>();

            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                var fs = Directory.GetFiles(fullPath);
                
                if (dirs.Length > 0)
                    directories.AddRange(dirs);

                if (fs.Length > 0)
                    files.AddRange(fs);
            }
            catch
            {
                //Ignore
            }

            foreach (var directoryPath in directories) 
            {
                var newItem = new TreeViewItem();
                newItem.Header = GetFileFolderName(directoryPath);
                newItem.Tag = directoryPath;
                newItem.Items.Add(null); 
                newItem.Expanded += Folder_Expanded;

                item.Items.Add(newItem);
            }

            foreach (var filesPath in files)
            {
                var newItem = new TreeViewItem();
                newItem.Header = GetFileFolderName(filesPath);
                newItem.Tag = filesPath;
                newItem.Expanded += Folder_Expanded;

                item.Items.Add(newItem);
            }
        }

        public static string GetFileFolderName(string path)
        {
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            var normalizedPath = path.Replace('/', '\\');
            var lastIndex = normalizedPath.LastIndexOf('\\');

            if (lastIndex <= 0)
                return path;

            return normalizedPath.Substring(lastIndex + 1);
        }
    }
}