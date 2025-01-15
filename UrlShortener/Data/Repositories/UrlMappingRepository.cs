using Data.Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UrlMappingRepository : IUrlMappingRepository
    {
        protected readonly ApplicationDbContext _dbContext;

        public UrlMappingRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(UrlMapping urlMapping)
        {
            await _dbContext.AddAsync(urlMapping);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<UrlMapping>> GetAllAsync()
        {
            return await _dbContext.UrlMappings.ToListAsync();
        }

        public async Task<UrlMapping> GetByIdAsync(int id)
        {
            return await _dbContext.UrlMappings.FirstAsync(x => x.Id == id);
        }

        public async Task<UrlMapping?> GetByUrl(string longUrl)
        {
            var result = await _dbContext.UrlMappings.FirstOrDefaultAsync(x => x.LongUrl == longUrl);
            if (result != null) 
            {
                return result;
            }

            return null;
        }

        public async Task<UrlMapping> UpdateAsync(UrlMapping urlMapping)
        {
            var result = await _dbContext.UrlMappings.FirstOrDefaultAsync(x => x.Id == urlMapping.Id);
            return new UrlMapping
            {
                Id = urlMapping.Id,
                LongUrl = urlMapping.LongUrl,
                ShortUrl = urlMapping.ShortUrl,
                Created = DateTime.Now
            };
        }

        public async Task DeleteAsync(int id)
        {
            var url = await _dbContext.UrlMappings.FirstOrDefaultAsync(x => x.Id == id);
            if (url != null)
            {
                _dbContext.UrlMappings.Remove(url);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
