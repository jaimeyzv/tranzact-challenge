using Moq;
using NUnit.Framework;
using SearchEngines.Config.IWrappers;
using SearchEngines.Config.Wrappers;
using SearchEngines.Core;
using System;
using System.Collections.Generic;

namespace SearchEngines.UnitTests
{
    [TestFixture]
    public class SearcherLoaderUnitTest
    {
        private Mock<ISearchFightSectionWrapper> searchFightSectionWrapperMock;

        [SetUp]
        public void SetUp()
        {
            searchFightSectionWrapperMock = new Mock<ISearchFightSectionWrapper>();
        }

        [Test]
        public void Handle_WhenEmptyWrapperIsSent_ReturnEmptyList()
        {
            var seacherLoader = new SearcherLoader(searchFightSectionWrapperMock.Object);
            var result = seacherLoader.Handle();

            Assert.IsNotNull(result);
        }

        [Test]
        public void Handle_WhenInvalidTypeIsTriedToBeInstantiated_ThrowInvalidOperationException()
        {
            var wrappedSearchers = new List<SearcherElementWrapper>
            {
                new SearcherElementWrapper{ Type = "InvalidNamespace.InvalidClass, InvalidAssembly" }
            };
            searchFightSectionWrapperMock.Setup(sfs => sfs.Searchers).Returns(wrappedSearchers);

            var searcherLoader = new SearcherLoader(searchFightSectionWrapperMock.Object);

            Assert.Throws<InvalidOperationException>(() => searcherLoader.Handle());
        }
    }
}