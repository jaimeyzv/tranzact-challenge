using System.Collections.Generic;

namespace SearchEngines.Config.Wrappers
{
    public class SearcherElementWrapper
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }

        public IReadOnlyDictionary<string, string> RequestHeaders { get; set; }
    }
}