using System.Runtime.Serialization;

namespace SearchEngines.Searches.Contracts
{
    [DataContract]
    public class GoogleSearchMain
    {
        [DataMember]
        public Queries queries { get; set; }
    }
}