﻿using System.Collections.Generic;

namespace SearchEngines.Models
{
    public class SearchResult
    {
        public string SearchTerm { get; set; }
        public IEnumerable<SearcherResponse> SearcherResults { get; set; }
    }
}