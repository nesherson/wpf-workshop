using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.FileApp
{
    public class DirectoryStructureViewModel : BaseViewModel
    {
        public DirectoryStructureViewModel()
        {
            Items = new ObservableCollection<DirectoryItemViewModel>(DirectoryStructure
                .GetLogicalDrives()
                .Select(x => new DirectoryItemViewModel(x.FullPath, DirectoryItemType.Drive)));
        }

        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }
    }
}