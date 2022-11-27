using LayeredArchitecture.Repositories.Models;

namespace LayeredArchitecture.Repositories.interfaces;


public interface IPurchaseRequestRepository
{
    Task<bool> Add(PurchaseRequest purchaseRequest);
    Task<PurchaseRequest> GetAsync(string id);
    Task<IEnumerable<PurchaseRequest>> GetListAsync(int pageSize,int pageNumber);
    Task<int> GetCountAsync();
    Task<bool> SaveChangesAsync();
    Task<bool> Delete(PurchaseRequest purchaseRequest);
}