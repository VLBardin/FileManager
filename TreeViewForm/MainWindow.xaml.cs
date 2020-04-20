using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TreeViewForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DirectoryStructureViewModel();
        }

        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (DirectoryItemViewModel)FolderView.SelectedItem;
            TestTextBox.Text = selectedItem.Name.ToString();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (DirectoryItemViewModel)FolderView.SelectedItem;
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(selectedItem.FullPath)
            {
                UseShellExecute = true
            };
            p.Start();
        }

        private void FolderView_GotFocus(object sender, RoutedEventArgs e)
        {
            var item = (TreeViewItem)FocusManager.GetFocusedElement(this);
            item.IsSelected = true;
            item.FontWeight = FontWeights.Bold;
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
