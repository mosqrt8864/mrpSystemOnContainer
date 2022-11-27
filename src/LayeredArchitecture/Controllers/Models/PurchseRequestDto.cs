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

    public override bool Equals(Object? obj)
    {
        if (obj == null)
            return false;

        GetPurchaseRequestResp? other = obj as GetPurchaseRequestResp;
        if ((Object?)other == null)
            return false;

        return this.Id == other.Id
            && this.CreateAt == other.CreateAt
            && this.Description == other.Description
            && this.PurchaseRequestItems.SequenceEqual(other.PurchaseRequestItems);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

public class GetPurchaseRequestItemResp :IMapFrom<PurchaseRequestItemBo>
{
    public int Id{set;get;}
    public string PRId{set;get;} = string.Empty; // 請購單ID
    public string PNId{set;get;} = string.Empty; // 料號ID
    public string Name {set;get;} = string.Empty;// 料號名稱
    public string Spec {set;get;} = string.Empty;// 料號規格
    public int Qty{set;get;} // 數量

    public override bool Equals(Object? obj)
    {
        if (obj == null)
            return false;

        GetPurchaseRequestItemResp? other = obj as GetPurchaseRequestItemResp;
        if ((Object?)other == null)
            return false;

        return this.Id == other.Id
            && this.PRId == other.PRId
            && this.PNId == other.PNId
            && this.Name == other.Name
            && this.Spec == other.Spec
            && this.Qty == other.Qty;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
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

    public override bool Equals(Object? obj)
    {
        if (obj == null)
            return false;

        GetPurchaseRequestListResp? other = obj as GetPurchaseRequestListResp;
        if ((Object?)other == null)
            return false;

        return this.Id == other.Id
            && this.CreateAt == other.CreateAt
            && this.Description == other.Description;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

public class UpdatePurchaseRequestReq
{
    public UpdatePurchaseRequestReq(){
        PurchaseRequestItems = new List<UpdatePurchaseRequestItemReq>();
    }
    public string Id{set;get;} = string.Empty; // 請購單號
    public DateTime CreateAt{set;get;} // 建立時間
    public string Description{set;get;} = string.Empty; // 描述
    public List<UpdatePurchaseRequestItemReq> PurchaseRequestItems{set;get;} // 請購單項目
}

public class UpdatePurchaseRequestItemReq
{
    public int Id{set;get;}
    public string PRId{set;get;} = string.Empty; // 請購單ID
    public string PNId{set;get;} = string.Empty; // 料號ID
    public string Name {set;get;} = string.Empty;// 料號名稱
    public string Spec {set;get;} = string.Empty;// 料號規格
    public int Qty{set;get;} // 數量
}