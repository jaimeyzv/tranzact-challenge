﻿using SearchEngines.Interface;
using SearchEngines.Models;
using System.Collections.Generic;
using System.Linq;

namespace SearchEngines.Core
{
    public class WinnerSearchCalculator : IWinnerSearchCalculator
    {
        public TotalSearchResult Handle(IEnumerable<SearchResult> searchResults)
        {
            string[] searchers = new string[] { };
            if (searchResults.Any())
                searchers = searchResults.First().SearcherResults.Select(x => x.SearcherName).ToArray();

            var individualWinners = new List<SearchWinner>();
            foreach (var searcher in searchers)
            {
                individualWinners.Add(new SearchWinner
                {
                    SearcherName = searcher,
                    SearchTerm = GetWinnerBySearcher(searcher, searchResults)
                });
            }

            return new TotalSearchResult
            {
                SearchResults = searchResults.ToList(),
                IndividualWinners = individualWinners,
                GlobalWinner = GetGlobalWinner(searchResults)
            };
        }

        private string GetGlobalWinner(IEnumerable<SearchResult> searchResults)
        {
            long winnerTotalSearch = default(long);
            string winnerSearchTerm = string.Empty;

            foreach (var searchResult in searchResults)
            {
                long currentTotalSearch = searchResult.SearcherResults.Sum(sum => sum.SearchTotal);

                if (currentTotalSearch >= winnerTotalSearch)
                {
                    winnerTotalSearch = currentTotalSearch;
                    winnerSearchTerm = searchResult.SearchTerm;
                }
            }

            return winnerSearchTerm;
        }

        private string GetWinnerBySearcher(string searcherName, IEnumerable<SearchResult> searchResults)
        {
            long maxTotalSearch = default(long);
            string winnerSearcher = string.Empty;

            foreach (var searchResult in searchResults)
            {
                var searchResponse = searchResult.SearcherResults.First(sr => sr.SearcherName.Equals(searcherName));

                if (searchResponse.SearchTotal >= maxTotalSearch)
                {
                    maxTotalSearch = searchResponse.SearchTotal;
                    winnerSearcher = searchResponse.SearchTerm;
                }
            }

            return winnerSearcher;
        }
    }
}