using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using BooksReader.Core.Models;

namespace BooksReader.Core.Services
{
    // This interface specifies methods used by some generated pages to show how they can be used.
    // TODO WTS: Delete this file once your app is using real data.
    public interface ISampleDataService
    {
        Task<IEnumerable<SampleOrder>> GetGridDataAsync();

        Task<IEnumerable<SampleOrder>> GetMasterDetailDataAsync();

        Task<IEnumerable<SampleOrder>> GetContentGridDataAsync();
    }
}
