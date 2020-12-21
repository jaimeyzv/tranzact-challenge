using SearchEngines.Models;
using System.Collections.Generic;

namespace SearchEngines.Interface
{
    public interface IWinnerSearchCalculator
    {
        TotalSearchResult Handle(IEnumerable<SearchResult> searchResults);
    }
}