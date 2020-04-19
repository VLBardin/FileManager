using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace TreeViewForm
{
    /// <summary>
    /// A view model for each dirrectory item
    /// </summary>
    public class DirectoryItemViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Type of the item
        /// </summary>
        public DirectoryItemType Type { get; set; }
        /// <summary>
        /// The absolute path to this item
        /// </summary>
        public string FullPath { get; set; }
        /// <summary>
        /// The name of file or folder
        /// </summary>
        public string Name { get { return Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }

        /// <summary>
        /// A list of all children in this item 
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        /// <summary>
        /// Indicates that this file can be expanded
        /// </summary>
        public bool CanExpand { get { return Type != DirectoryItemType.File; } }

        /// <summary>
        /// Indicates if the current item is expanded or not 
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                return Children?.Count(f => f != null) > 0;
            }
            set
            {
                if (value)    // If UI tells us to expand
                    Expand();
                else
                    ClearChildren();
            }
        }

        /// <summary>
        /// Contains information about file
        /// </summary>
        public FileInfo FileInfo { get; set; }

        /// <summary>
        /// Contains directory info
        /// </summary>
        public DirectoryInfo DirectoryInfo { get; set; }
        #endregion

        #region Public Commands

        /// <summary>
        /// Command to expand this item
        /// </summary>
        /// <returns></returns>
        public ICommand ExpandCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="fullPath">The full path of this item</param>
        /// <param name="type">The type of item</param>
        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            ExpandCommand = new RelayCommand(Expand);
            FullPath = fullPath;
            Type = type;

            Children = new ObservableCollection<DirectoryItemViewModel>();

            try
            {
                if (Type != DirectoryItemType.File && !DirectoryStructure.CheckDirectoryEmpty(FullPath))
                    Children.Add(null);
            }
            catch { }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Removes all children from the list, adding a dummy item to show the expand icon if required
        /// </summary>
        private void ClearChildren()
        {
            Children = new ObservableCollection<DirectoryItemViewModel>();

            if (Type != DirectoryItemType.File)
                Children.Add(null);
        }

        /// <summary>
        /// Expands this directory and find all children
        /// </summary>
        private void Expand()
        {
            if (Type == DirectoryItemType.File)
                return;

            Children = new ObservableCollection<DirectoryItemViewModel>(DirectoryStructure.GetDirectoryContents(FullPath)
                            .Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)));
        }

        #endregion
    }
}
