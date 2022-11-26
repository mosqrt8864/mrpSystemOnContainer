using LayeredArchitecture.Services.interfaces;
using LayeredArchitecture.Services.Models;
using LayeredArchitecture.Repositories.Models;
using LayeredArchitecture.Repositories.interfaces;
using AutoMapper;

namespace LayeredArchitecture.Services;

public class PurchaseRequestService : IPurchaseRequestService
{
    private readonly IPurchaseRequestRepository _repository;
    private readonly IMapper _mapper;

    public PurchaseRequestService(IPurchaseRequestRepository repository,IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<bool> CreatePurchaseRequest(PurchaseRequestBo purchaseRequest)
    {
        var purchaseRequestPo = _mapper.Map<PurchaseRequest>(purchaseRequest);
        await _repository.Add(purchaseRequestPo);
        return true;
    }
    public async Task<PurchaseRequestBo> GetPurchaseRequest(string id)
    {
        var purchaseRequestPo = await _repository.GetAsync(id);
        var result = _mapper.Map<PurchaseRequestBo>(purchaseRequestPo);
        return result;
    }
}