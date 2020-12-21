using Moq;
using NUnit.Framework;
using SearchEngines.Core;
using SearchEngines.Interface;
using SearchEngines.Models;
using System;
using System.Collections.Generic;

namespace SearchEngines.UnitTests
{
    [TestFixture]
    public class SearchProcessUnitTest
    {
        private Mock<ISearcherLoader> searcherLoaderMock;
        private Mock<IWinnerSearchCalculator> winnerSearchCalculatorMock;

        [SetUp]
        public void SetUp()
        {
            searcherLoaderMock = new Mock<ISearcherLoader>();
            winnerSearchCalculatorMock = new Mock<IWinnerSearchCalculator>();
        }

        [Test]
        public void Run_WhenEmptyValuesAreSent_RunSuccessfully()
        {
            searcherLoaderMock.Setup(sl => sl.Handle())
                .Returns(new List<ISearcher>());
            winnerSearchCalculatorMock.Setup(wsc => wsc.Handle(It.IsAny<IEnumerable<SearchResult>>()))
                .Returns(new TotalSearchResult());
            var searchProcess = new SearchProcess(searcherLoaderMock.Object, winnerSearchCalculatorMock.Object);

            var processResult = searchProcess.Run(new string[] { }).Result;
            
            Assert.IsNotNull(processResult);
        }

        [Test]
        public void Run_WhenNullValuesAreSent_ThrowsNullReferenceException()
        {
            searcherLoaderMock.Setup(sl => sl.Handle())
                   .Returns(new List<ISearcher>());

            var searchProcess = new SearchProcess(searcherLoaderMock.Object, null);

            Assert.ThrowsAsync<NullReferenceException>(() => searchProcess.Run(null));
        }        
    }
}