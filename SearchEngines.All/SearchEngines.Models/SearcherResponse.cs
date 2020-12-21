namespace SearchEngines.Models
{
    public class SearcherResponse
    {
        public string SearchTerm { get; set; }
        public string SearcherName { get; set; }
        public long SearchTotal { get; set; }
    }
}