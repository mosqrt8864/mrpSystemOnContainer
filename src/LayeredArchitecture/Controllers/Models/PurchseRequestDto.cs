using LayeredArchitecture.Services.Models;
using LayeredArchitecture.Commons.Mappings;
namespace LayeredArchitecture.Controllers.Models;

public class CreatePurchaseRequestReq
{
    public CreatePurchaseRequestReq(){
        PurchaseRequestItems = new List<CreatePurchaseRequestItemReq>();
    }
    public string Id{set;get;} = string.Empty; // 請購單號
    public DateTime CreateAt{set;get;} // 建立時間
    public string Description{set;get;} = string.Empty; // 描述
    public List<CreatePurchaseRequestItemReq> PurchaseRequestItems{set;get;} // 請購單項目
}

public class CreatePurchaseRequestItemReq
{
    public int Id{set;get;}
    public string PRId{set;get;} = string.Empty; // 請購單ID
    public string PNId{set;get;} = string.Empty; // 料號ID
    public string Name {set;get;} = string.Empty;// 料號名稱
    public string Spec {set;get;} = string.Empty;// 料號規格
    public int Qty{set;get;} // 數量
}

public class GetPurchaseRequestResp :IMapFrom<PurchaseRequestBo>
{
    public GetPurchaseRequestResp(){
        PurchaseRequestItems = new List<GetPurchaseRequestItemResp>();
    }
    public string Id{set;get;} = string.Empty; // 請購單號
    public DateTime CreateAt{set;get;} // 建立時間
    public string Description{set;get;} = string.Empty; // 描述
    public IEnumerable<GetPurchaseRequestItemResp> PurchaseRequestItems{set;get;} // 請購單項目
}

public class GetPurchaseRequestItemResp :IMapFrom<PurchaseRequestItemBo>
{
    public int Id{set;get;}
    public string PRId{set;get;} = string.Empty; // 請購單ID
    public string PNId{set;get;} = string.Empty; // 料號ID
    public string Name {set;get;} = string.Empty;// 料號名稱
    public string Spec {set;get;} = string.Empty;// 料號規格
    public int Qty{set;get;} // 數量
}

public class GetPurchaseRequestListReq
{
    public int PageSize{set;get;}=1;
    public int PageNumber{set;get;}=10;
}

public class GetPurchaseRequestListResp :IMapFrom<PurchaseRequestBo>
{
    public string Id{set;get;} = string.Empty; // 請購單號
    public DateTime CreateAt{set;get;} // 建立時間
    public string Description{set;get;} = string.Empty; // 描述
}