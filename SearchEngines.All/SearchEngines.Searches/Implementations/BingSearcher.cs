using SearchEngines.Models;
using SearchEngines.Searches.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace SearchEngines.Searches
{
    public class BingSearcher : BaseSearcher
    {
        private static HttpClient httpClient = new HttpClient();

        public BingSearcher(string name, string url)
            : base(name, url)
        {
        }

        public BingSearcher(string name, string url, Dictionary<string, string> headers)
            : base(name, url, headers)
        {
        }
        
        public override async Task<SearcherResponse> Handle(string searchTerm)
        {
            long searchCount = default(long);
            string requestUrl = $"{base.Url}{searchTerm}";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUrl)
            };

            foreach (var header in base.Headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            using (var response = await httpClient.SendAsync(request))
            {
                var serializer = new DataContractJsonSerializer(typeof(BingSearchMain));
                var streamContent = await response.Content.ReadAsStreamAsync();
                var data = (BingSearchMain)serializer.ReadObject(streamContent);

                searchCount = data.webPages.totalEstimatedMatches;
            }

            return new SearcherResponse { SearchTerm = searchTerm,
                SearcherName = base.Name,
                SearchTotal = searchCount };
        }
    }
}