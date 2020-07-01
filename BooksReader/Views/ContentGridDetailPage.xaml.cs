using System;

using BooksReader.Core.Models;
using BooksReader.ViewModels;

using Microsoft.Toolkit.Uwp.UI.Animations;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace BooksReader.Views
{
    public sealed partial class ContentGridDetailPage : Page
    {
        public ContentGridDetailPage()
        {
            InitializeComponent();
        }

        private ContentGridDetailViewModel ViewModel => DataContext as ContentGridDetailViewModel;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.RegisterElementForConnectedAnimation("animationKeyContentGrid", itemHero);
        }
    }
}
