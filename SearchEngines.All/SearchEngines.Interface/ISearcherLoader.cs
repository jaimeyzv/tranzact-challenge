using System.Collections.Generic;

namespace SearchEngines.Interface
{
    public interface ISearcherLoader
    {
        IEnumerable<ISearcher> Handle();
    }
}