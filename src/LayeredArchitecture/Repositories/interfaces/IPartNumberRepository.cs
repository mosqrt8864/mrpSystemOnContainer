using LayeredArchitecture.Repositories.Models;

namespace LayeredArchitecture.Repositories.interfaces;

public interface IPartNumberRepository
{
    Task Add(PartNumber partNumber);
    Task<PartNumber> GetAsync(string id);
    Task<IEnumerable<PartNumber>> GetListAsync(int pageSize,int pageNumber);
    Task<int> GetCountAsync();
    Task SaveChangesAsync();
}