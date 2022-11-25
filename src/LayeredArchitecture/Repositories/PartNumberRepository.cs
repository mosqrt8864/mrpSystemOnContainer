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
    public async Task Add(PartNumber partNumber)
    {
        _context.PartNumbers.Add(partNumber);
        await _context.SaveChangesAsync();
    }
    public async Task<PartNumber> GetAsync(string id)
    {
        return await _context.PartNumbers.FirstOrDefaultAsync(x=>x.Id == id);
    }

    public async Task<IEnumerable<PartNumber>> GetListAsync(int pageSize,int pageNumber)
    {
        return await _context.PartNumbers.AsNoTracking().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    public async Task<int> GetCountAsync()
    {
        return await _context.PartNumbers.AsNoTracking().CountAsync();
    }

    public async Task SaveChangesAsync(){
        await _context.SaveChangesAsync();
    }
}