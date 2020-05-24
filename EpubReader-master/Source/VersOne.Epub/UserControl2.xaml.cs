using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace VersOne.Epub
{
    public class UserControl2 : UserControl
    {
        public UserControl2()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
