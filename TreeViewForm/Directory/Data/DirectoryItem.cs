using System.IO;

namespace TreeViewForm
{
    /// <summary>
    /// Informantion about directory item such as a driver, a folder or file
    /// </summary>
    public class DirectoryItem
    {
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
        /// Constains file information
        /// </summary>
        public FileInfo FileInfo { get; set; }
        /// <summary>
        /// Selected directory information
        /// </summary>
        public DirectoryInfo DirectoryInfo { get; set; }
    }
}
