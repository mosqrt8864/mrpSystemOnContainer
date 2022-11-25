using LayeredArchitecture.Repositories.Models;

namespace LayeredArchitecture.Repositories.interfaces;


public interface IPurchaseRequestRepository
{
    Task Add(PurchaseRequest purchaseRequest);
    Task<PurchaseRequest> GetAsync(string id);
    Task<IEnumerable<PurchaseRequest>> GetListAsync(int pageSize,int pageNumber);
    Task<int> GetCountAsync();
    Task SaveChangesAsync();
    Task Delete(PurchaseRequest purchaseRequest);
}