using System;
using System.Collections.Generic;
using System.Text;
using BookReader.Models;
using System.Collections.ObjectModel;

namespace BookReader.ViewModels
{
    public class BookListViewModel : ViewModelBase
    {
        public BookListViewModel(IEnumerable<Book> books)
        {
            Books = new ObservableCollection<Book>(books);
        }

        public ObservableCollection<Book> Books { get; }

    }
}
