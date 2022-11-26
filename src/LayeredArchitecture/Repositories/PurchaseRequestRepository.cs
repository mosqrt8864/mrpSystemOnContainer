using LayeredArchitecture.Repositories.interfaces;
using LayeredArchitecture.Repositories.Models;
using Microsoft.EntityFrameworkCore;
namespace LayeredArchitecture.Repositories;

public class PurchaseRequestRepository :IPurchaseRequestRepository
{
    private readonly MRPSystemDbContext _context;
    public PurchaseRequestRepository(MRPSystemDbContext context)
    {
        _context = context;
    }

    public async Task Add(PurchaseRequest purchaseRequest)
    {
        purchaseRequest.CreateAt = DateTime.Now;
        _context.PurchaseRequests.Add(purchaseRequest);
        await _context.SaveChangesAsync();
    }

    public async Task<PurchaseRequest> GetAsync(string id)
    {
        return await _context.PurchaseRequests.Include(o => o.PurchaseRequestItems).FirstOrDefaultAsync(x=>x.Id == id);
    }

    public async Task<IEnumerable<PurchaseRequest>> GetListAsync(int pageSize,int pageNumber)
    {
        return await _context.PurchaseRequests.AsNoTracking().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    public async Task<int> GetCountAsync()
    {
        return await _context.PurchaseRequests.AsNoTracking().CountAsync();
    }
    public async Task SaveChangesAsync(){
        await _context.SaveChangesAsync();
    }
    public async Task Delete(PurchaseRequest purchaseRequest)
    {
        _context.Remove(purchaseRequest);
        await _context.SaveChangesAsync();
    }
}