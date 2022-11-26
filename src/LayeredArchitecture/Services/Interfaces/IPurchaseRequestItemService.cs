using LayeredArchitecture.Services.Models;
namespace LayeredArchitecture.Services.interfaces;

public interface IPurchaseRequestItemService
{
    Task<bool> DeletePurchaseRequestItem(int id);
}