using System.Collections.Generic;

namespace SearchEngines.Models
{
    public class TotalSearchResult
    {
        public List<SearchResult> SearchResults { get; set; }
        public List<SearchWinner> IndividualWinners { get; set; }
        public string GlobalWinner { get; set; }
    }
}