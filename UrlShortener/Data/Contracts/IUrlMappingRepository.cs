using Entities;

namespace Data.Contracts
{
    public interface IUrlMappingRepository
    {
        Task AddAsync(UrlMapping url);
        Task<UrlMapping> GetByIdAsync(int id);
        Task<IEnumerable<UrlMapping>> GetAllAsync();
        Task<UrlMapping?> GetByUrl(string longUrl);
        Task<UrlMapping> UpdateAsync(UrlMapping urlMapping);
        Task DeleteAsync(int id);

    }
}
