using System.Text;
using Data;
using Entities;

namespace Services
{
    public class UrlShortenerService
    {
        private const string _base62Chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
       
        // Should be changed to a repository instance
        private readonly ApplicationDbContext _dbContext;

        public UrlShortenerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void ShortenUrl(int id, string url)
        {
            var urlMapping = new UrlMapping 
            {
                Id = id,
                LongUrl = url,
                ShortUrl = GenerateShortUrl(),
                Created = DateTime.Now
            };

            // use the repository instance to access database
        }

        public string GenerateShortUrl()
        {
            Random rand = new Random();
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < 10; i++)
            {
                int index = rand.Next(62);
                result.Append(_base62Chars[index]);
            }

            return result.ToString();
        }
    }
}
