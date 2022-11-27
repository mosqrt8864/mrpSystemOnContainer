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

    public override bool Equals(Object? obj)
    {
        if (obj == null)
            return false;

        PurchaseRequestBo? other = obj as PurchaseRequestBo;
        if ((Object?)other == null)
            return false;

        return this.Id == other.Id
            && this.CreateAt == other.CreateAt
            && this.Description == other.Description
            && this.PurchaseRequestItems.SequenceEqual(PurchaseRequestItems);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}


public class PurchaseRequestListBo
{
    public IEnumerable<PurchaseRequestBo> Items{set;get;} = new List<PurchaseRequestBo>();
    public int Count{set;get;}

    public override bool Equals(Object? obj)
    {
        if (obj == null)
            return false;

        PurchaseRequestListBo? other = obj as PurchaseRequestListBo;
        if ((Object?)other == null)
            return false;

        return this.Count == other.Count
            && this.Items.SequenceEqual(other.Items);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}