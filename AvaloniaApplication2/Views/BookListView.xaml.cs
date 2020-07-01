using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace BookReader.Views
{
    public class BookListView : UserControl
    {
        public BookListView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
