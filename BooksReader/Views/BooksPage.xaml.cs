using System;

using BooksReader.ViewModels;

using Windows.UI.Xaml.Controls;

namespace BooksReader.Views
{
    public sealed partial class BooksPage : Page
    {
        private BooksViewModel ViewModel => DataContext as BooksViewModel;

        public BooksPage()
        {
            InitializeComponent();
        }
    }
}
