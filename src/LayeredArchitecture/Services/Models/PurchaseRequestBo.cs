using LayeredArchitecture.Commons.Mappings;
using LayeredArchitecture.Controllers.Models;
using LayeredArchitecture.Repositories.Models;

namespace LayeredArchitecture.Services.Models;

public class PurchaseRequestBo:IMapFrom<CreatePurchaseRequestReq>,IMapFrom<PurchaseRequest>,IMapFrom<UpdatePurchaseRequestReq>
{
    public PurchaseRequestBo(){
        PurchaseRequestItems = new List<PurchaseRequestItemBo>();
    }
    public string Id{set;get;} = string.Empty; // 請購單號
    public DateTime CreateAt{set;get;} // 建立時間
    public string Description{set;get;} = string.Empty; // 描述
    public List<PurchaseRequestItemBo> PurchaseRequestItems{set;get;} // 請購單項目
}


public class PurchaseRequestListBo
{
    public IEnumerable<PurchaseRequestBo> Items{set;get;}
    public int Count{set;get;}
}