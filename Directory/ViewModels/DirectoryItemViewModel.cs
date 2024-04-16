using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;

namespace WPF.Workshop
{
    public class DirectoryItemViewModel : BaseViewModel
    {
        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            FullPath = fullPath;
            Type = type;

            Children = new ObservableCollection<DirectoryItemViewModel>();

            if (Type != DirectoryItemType.File)
                Children.Add(null);

            ExpandCommand = new RelayCommand(Expand);
        }
        public DirectoryItemType Type { get; set; }
        public string FullPath { get; set; }
        public string Name => Type == DirectoryItemType.Drive ? FullPath : DirectoryStructure.GetFileFolderName(FullPath);
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }
        public bool CanExpand => Type != DirectoryItemType.File;
        public bool IsExpanded 
        { 
            get => Children?.Count(x => x != null) > 0;
            set
            {
                if (value == true)
                    Expand();
                else
                    ClearChildren();
            }
        }

        public ICommand ExpandCommand { get; set; }

        private void ClearChildren()
        {
            Children.Clear();

            if (Type != DirectoryItemType.File)
                Children.Add(null);
        }

        private void Expand()
        {
            if (Type == DirectoryItemType.File)
                return;

            Children = new ObservableCollection<DirectoryItemViewModel>(
                DirectoryStructure
                .GetDirectoryContent(FullPath)
                .Select(x => new DirectoryItemViewModel(x.FullPath, x.Type)));

        }
    }
}
