using System.Runtime.Serialization;

namespace SearchEngines.Searches.Contracts
{
    [DataContract]
    public class BingSearchMain
    {
        [DataMember]
        public WebPages webPages
        {
            get; set;
        }
    }
}