using System;

using BooksReader.ViewModels;

using Windows.UI.Xaml.Controls;

namespace BooksReader.Views
{
    public sealed partial class ContentGridPage : Page
    {
        private ContentGridViewModel ViewModel => DataContext as ContentGridViewModel;

        public ContentGridPage()
        {
            InitializeComponent();
        }
    }
}
