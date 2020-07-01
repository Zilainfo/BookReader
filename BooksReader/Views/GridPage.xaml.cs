using System;

using BooksReader.ViewModels;

using Windows.UI.Xaml.Controls;

namespace BooksReader.Views
{
    public sealed partial class GridPage : Page
    {
        private GridViewModel ViewModel => DataContext as GridViewModel;

        // TODO WTS: Change the grid as appropriate to your app, adjust the column definitions on GridPage.xaml.
        // For more details see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid
        public GridPage()
        {
            InitializeComponent();
        }
    }
}
