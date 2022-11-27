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

    public async Task<bool> Add(PurchaseRequest purchaseRequest)
    {
        purchaseRequest.CreateAt = DateTime.Now;
        _context.PurchaseRequests.Add(purchaseRequest);
        var added = await _context.SaveChangesAsync();
        return added > 0;
    }

    public async Task<PurchaseRequest> GetAsync(string id)
    {
        var result = await _context.PurchaseRequests.Include(o => o.PurchaseRequestItems).FirstOrDefaultAsync(x=>x.Id == id);
        return result == null ? new PurchaseRequest(): result;
    }

    public async Task<IEnumerable<PurchaseRequest>> GetListAsync(int pageSize,int pageNumber)
    {
        return await _context.PurchaseRequests.AsNoTracking().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    public async Task<int> GetCountAsync()
    {
        return await _context.PurchaseRequests.AsNoTracking().CountAsync();
    }
    public async Task<bool> SaveChangesAsync(){
        var saved = await _context.SaveChangesAsync();
        return saved > 0;
    }
    public async Task<bool> Delete(PurchaseRequest purchaseRequest)
    {
        _context.Remove(purchaseRequest);
        var deleted = await _context.SaveChangesAsync();
        return deleted > 0;
    }
}