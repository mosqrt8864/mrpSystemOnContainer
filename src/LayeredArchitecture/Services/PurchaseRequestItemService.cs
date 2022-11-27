using LayeredArchitecture.Services.interfaces;
using LayeredArchitecture.Services.Models;
using LayeredArchitecture.Repositories.Models;
using LayeredArchitecture.Repositories.interfaces;
using AutoMapper;

namespace LayeredArchitecture.Services;

public class PurchaseRequestItemService :IPurchaseRequestItemService
{
    private readonly IPurchaseRequestItemRepository _repository;

    public PurchaseRequestItemService(IPurchaseRequestItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> DeletePurchaseRequestItem(int id)
    {
        var purchaseRequestItem = await _repository.GetAsync(id);
        return await _repository.Delete(purchaseRequestItem);;
    }
}