using SearchEngines.Models;
using System.Threading.Tasks;

namespace SearchEngines.Interface
{
    public interface ISearcher
    {
        string Name { get; }
        Task<SearcherResponse> Handle(string searchTerm);
    }
}