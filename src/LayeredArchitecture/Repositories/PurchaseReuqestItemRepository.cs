using LayeredArchitecture.Repositories.interfaces;
using LayeredArchitecture.Repositories.Models;
using Microsoft.EntityFrameworkCore;
namespace LayeredArchitecture.Repositories;

public class PurchaseRequestItemRepository :IPurchaseRequestItemRepository
{
    private readonly MRPSystemDbContext _context;
    public PurchaseRequestItemRepository(MRPSystemDbContext context)
    {
        _context = context;
    }

    public async Task Delete(PurchaseRequestItem item)
    {
        _context.Remove(item);
        await _context.SaveChangesAsync();
    }
    public async Task<PurchaseRequestItem> GetAsync(int id)
    {
        var result = await _context.PurchaseRequestItems.FirstOrDefaultAsync(o=>o.Id ==id);
        return result == null ? new PurchaseRequestItem():result;
    }
}