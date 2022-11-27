using LayeredArchitecture.Repositories.interfaces;
using LayeredArchitecture.Repositories.Models;
using Microsoft.EntityFrameworkCore;
namespace LayeredArchitecture.Repositories;

public class PartNumberRepository : IPartNumberRepository
{
    private readonly MRPSystemDbContext _context;
    public PartNumberRepository(MRPSystemDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Add(PartNumber partNumber)
    {
        _context.PartNumbers.Add(partNumber);
        var added = await _context.SaveChangesAsync();
        return added > 0;
    }
    public async Task<PartNumber> GetAsync(string id)
    {
        var result = await _context.PartNumbers.FirstOrDefaultAsync(x=>x.Id == id);
        return result==null?new PartNumber():result;
    }

    public async Task<IEnumerable<PartNumber>> GetListAsync(int pageSize,int pageNumber)
    {
        return await _context.PartNumbers.AsNoTracking().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    public async Task<int> GetCountAsync()
    {
        return await _context.PartNumbers.AsNoTracking().CountAsync();
    }

    public async Task<bool> SaveChangesAsync(){
        var saved = await _context.SaveChangesAsync();
        return saved > 0;
    }
}