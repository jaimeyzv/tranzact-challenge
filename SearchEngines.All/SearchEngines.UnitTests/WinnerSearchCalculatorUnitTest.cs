using NUnit.Framework;
using SearchEngines.Core;
using SearchEngines.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchEngines.UnitTests
{
    [TestFixture]
    public class WinnerSearchCalculatorUnitTest
    {
        [Test]
        public void Handle_WhenEmptyListIsSent_ReturnEmptyResult()
        {
            var winnerSearchCalculator = new WinnerSearchCalculator();
            var totalResult = winnerSearchCalculator.Handle(new List<SearchResult>());

            Assert.IsNotNull(totalResult);
            Assert.IsTrue(!totalResult.SearchResults.Any());
            Assert.IsTrue(!totalResult.IndividualWinners.Any());
            Assert.IsTrue(string.IsNullOrEmpty(totalResult.GlobalWinner));
        }

        [Test]
        public void Handle_WhenNullIsSent_ThrowArgumentNullException()
        {
            var winnerSearchCalculator = new WinnerSearchCalculator();

            Assert.Throws<ArgumentNullException>(() => winnerSearchCalculator.Handle(null));
        }

        [Test]
        public void Handle_WhenValidCollectionIsSent_ReturnGreatestValuesAsWinners()
        {
            var searchResults = new List<SearchResult>
            {
                new SearchResult { SearchTerm = "ASP.NET Web APIs", SearcherResults = new List<SearcherResponse>
                    {
                        new SearcherResponse { SearchTerm = "ASP.NET Web APIs", SearcherName = "GoogleSearcher", SearchTotal = 2200000 },
                        new SearcherResponse { SearchTerm = "ASP.NET Web APIs", SearcherName = "BingSearcher", SearchTotal = 205000 }
                    }
                },
                new SearchResult { SearchTerm = "Java", SearcherResults = new List<SearcherResponse>
                    {
                        new SearcherResponse { SearchTerm = "Java", SearcherName = "GoogleSearcher", SearchTotal = 175000 },
                        new SearcherResponse { SearchTerm = "Java", SearcherName = "BingSearcher", SearchTotal = 240000 }
                    }
                }
            };

            var winnerSearchCalculator = new WinnerSearchCalculator();
            var totalResult = winnerSearchCalculator.Handle(searchResults);
            
            Assert.IsNotNull(totalResult);
            Assert.IsTrue(totalResult.SearchResults.Any());
            Assert.IsTrue(totalResult.IndividualWinners.Any());
            Assert.AreEqual(totalResult.IndividualWinners.First().SearcherName, "GoogleSearcher");
            Assert.AreEqual(totalResult.IndividualWinners.First().SearchTerm, "ASP.NET Web APIs");
            Assert.AreEqual(totalResult.IndividualWinners.Last().SearcherName, "BingSearcher");
            Assert.AreEqual(totalResult.IndividualWinners.Last().SearchTerm, "Java");
            Assert.AreEqual(totalResult.GlobalWinner, "ASP.NET Web APIs");
        }
    }
}