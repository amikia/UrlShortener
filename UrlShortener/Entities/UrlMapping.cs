namespace Entities
{
    public class UrlMapping
    {
        public int Id { get; set; }
        public required string LongUrl { get; set; }
        public required string ShortUrl { get; set; }
        public DateTime Created { get; set; }
    }
}
