using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace BookReader.Views
{
    public class BookList : UserControl
    {
        public BookList()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
