using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace BookReader.Views
{
    public class sa : UserControl
    {
        public sa()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
