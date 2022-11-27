using LayeredArchitecture.Repositories.Models;

namespace LayeredArchitecture.Repositories.interfaces;

public interface IPurchaseRequestItemRepository
{
    Task<bool> Delete(PurchaseRequestItem purchaseRequestItem);
    Task<PurchaseRequestItem> GetAsync(int id);
}