using System;
using System.Collections.Generic;
using System.Text;
using BookReader.Services;

namespace BookReader.ViewModels
{ 
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(BookReaderContext db)
        {
            List = new BookListViewModel(db.Books);
        }
        public string Greeting => "Welcome to Avalonia!";
        public BookListViewModel List { get; }
    }
}
