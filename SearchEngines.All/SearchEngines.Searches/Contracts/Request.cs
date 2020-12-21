using System.Runtime.Serialization;

namespace SearchEngines.Searches.Contracts
{
    [DataContract]
    public class Request
    {
        [DataMember]
        public long totalResults { get; set; }
    }
}