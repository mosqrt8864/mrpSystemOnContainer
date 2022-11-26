using LayeredArchitecture.Repositories.Models;

namespace LayeredArchitecture.Repositories.interfaces;

public interface IPurchaseRequestItemRepository
{
    Task Delete(PurchaseRequestItem purchaseRequestItem);
    Task<PurchaseRequestItem> GetAsync(int id);
}