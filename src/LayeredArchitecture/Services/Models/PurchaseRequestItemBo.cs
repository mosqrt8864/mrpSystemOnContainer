using LayeredArchitecture.Commons.Mappings;
using LayeredArchitecture.Controllers.Models;
using LayeredArchitecture.Repositories.Models;
namespace LayeredArchitecture.Services.Models;

public class PurchaseRequestItemBo:IMapFrom<CreatePurchaseRequestItemReq>,IMapFrom<PurchaseRequestItem>
{
    public int Id{set;get;}
    public string PRId{set;get;} = string.Empty; // 請購單ID
    public string PNId{set;get;} = string.Empty; // 料號ID
    public string Name {set;get;} = string.Empty;// 料號名稱
    public string Spec {set;get;} = string.Empty;// 料號規格
    public int Qty{set;get;} // 數量
}