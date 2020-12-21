using SearchEngines.Interface;
using SearchEngines.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchEngines.Searches
{
    public abstract class BaseSearcher : ISearcher
    {
        public string Name { get; }
        public string Url { get; }
        public Dictionary<string, string> Headers { get; }

        public BaseSearcher(string name, string url)
        {
            this.Name = name;
            this.Url = url;
        }
        public BaseSearcher(string name, string url, Dictionary<string, string> headers)
            : this(name, url)
        {
            this.Headers = headers;
        }

        public abstract Task<SearcherResponse> Handle(string searchTerm);
    }
}