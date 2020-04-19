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
