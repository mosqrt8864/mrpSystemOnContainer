using LayeredArchitecture.Services.Models;
namespace LayeredArchitecture.Services.interfaces;

public interface IPurchaseRequestService
{
   Task<bool>CreatePurchaseRequest(PurchaseRequestBo purchaseRequest);
   Task<PurchaseRequestBo> GetPurchaseRequest(string id);
   Task<PurchaseRequestListBo> GetPurchaseRequestList(int pageSize,int pageNumber);
    Task<bool> UpdatePurchaseRequest(PurchaseRequestBo purchaseRequest);
}