using System.Runtime.Serialization;

namespace SearchEngines.Searches.Contracts
{
    [DataContract]
    public class Queries
    {
        [DataMember]
        public Request[] request { get; set; }
    }
}