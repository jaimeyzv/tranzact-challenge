using SearchEngines.Models;
using SearchEngines.Searches.Contracts;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace SearchEngines.Searches
{
    public class GoogleSearcher : BaseSearcher
    {
        private static HttpClient httpClient = new HttpClient();

        public GoogleSearcher(string name, string url)
            : base(name, url)
        {
        }
        public GoogleSearcher(string name, string url, Dictionary<string, string> headers)
            : base(name, url, headers)
        {
        }

        public override async Task<SearcherResponse> Handle(string searchTerm)
        {
            long searchCount = default(long);
            string requestUrl = $"{base.Url}{searchTerm}";
            requestUrl = requestUrl.Replace(";;", "&");

            using (var response = await httpClient.GetStreamAsync(requestUrl))
            {
                var serializer = new DataContractJsonSerializer(typeof(GoogleSearchMain));
                var data = (GoogleSearchMain)serializer.ReadObject(response);

                searchCount = data.queries.request[0].totalResults;
            }

            return new SearcherResponse { SearchTerm = searchTerm,
                SearcherName = base.Name,
                SearchTotal = searchCount };
        }
    }
}