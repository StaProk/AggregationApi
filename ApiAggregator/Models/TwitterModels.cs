namespace AggregationService.Models
{
    public class TweetResponse
    {
        public Meta Meta { get; set; }
        public List<TweetData> Data { get; set; }
        public TweetResponse()
        {
            if(Meta == null)
            {
                Meta = new Meta();
            }
            if(Data == null)
            { 
                Data = [];
            }
        }
    }

    public class Meta
    {
        public int ResultCount { get; set; }
        public string? NextToken { get; set; }
    }

    public class TweetData
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public TweetData() 
        {
            if(Id == null)
            {
                Id = "";
            }
            if(Text == null)
            {
                Text = "";
            }
        }
    }
}
