using System;

using BooksReader.ViewModels;

using Windows.UI.Xaml.Controls;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using Windows.Storage;

namespace BooksReader.Views
{
    public sealed partial class AddBookPage : Page
    {
        private AddBookViewModel ViewModel => DataContext as AddBookViewModel;

        public AddBookPage()
        {
            InitializeComponent();
        }

        private async void ButtonBook_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".epub");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                chooseBookText.Text = file.Path;
            }
            else
            {
                //chooseBookText.Text = "Select book";
            }
        }

        private async void ButtonImg_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                chooseImgText.Text = file.Path;
               
            }
            else
            {
              
            }
        }
        private async void ButtonAdd_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
          
        }

    }
}
