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
