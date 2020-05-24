using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace VersOne.Epub
{
    public class UserControl3 : UserControl
    {
        public UserControl3()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
