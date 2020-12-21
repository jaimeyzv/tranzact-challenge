using System.Runtime.Serialization;

namespace SearchEngines.Searches.Contracts
{
    [DataContract]
    public class WebPages
    {
        [DataMember]
        public long totalEstimatedMatches { get; set; }
    }
}