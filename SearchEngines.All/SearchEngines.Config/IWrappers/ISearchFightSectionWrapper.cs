using SearchEngines.Config.Wrappers;
using System.Collections.Generic;

namespace SearchEngines.Config.IWrappers
{
    public interface ISearchFightSectionWrapper
    {
        IEnumerable<SearcherElementWrapper> Searchers { get; }
    }
}