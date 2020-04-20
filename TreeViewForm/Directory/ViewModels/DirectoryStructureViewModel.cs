using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace TreeViewForm
{
    /// <summary>
    /// The view model for the application main Directory view
    /// </summary>
    public class DirectoryStructureViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// A list of all directories on the machine
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }
        public FileInfo FileInfo { get; set; } = new FileInfo(@"C:\Users\User\Desktop\Влад\desktopBG.jpg");

        #endregion

        #region

        /// <summary>
        /// Default constructor
        /// </summary>
        public DirectoryStructureViewModel()
        {
            Items = new ObservableCollection<DirectoryItemViewModel>(DirectoryStructure.GetLogicalDrives()
                .Select(drive => new DirectoryItemViewModel(drive.FullPath, drive.Type)));
        }

        #endregion
    }
}
