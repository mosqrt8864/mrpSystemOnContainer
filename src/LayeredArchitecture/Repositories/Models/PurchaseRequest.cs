using System.ComponentModel.DataAnnotations;
using LayeredArchitecture.Services.Models;
using LayeredArchitecture.Commons.Mappings;
namespace LayeredArchitecture.Repositories.Models;

public class PurchaseRequest: IMapFrom<PurchaseRequestBo>
{
    public PurchaseRequest()
    {
        PurchaseRequestItems = new List<PurchaseRequestItem>();
    }
    [Key]
    public string Id{set;get;} = string.Empty; // 請購單號
    public DateTime CreateAt{set;get;} // 建立時間
    public string Description{set;get;} = string.Empty; // 描述
    public List<PurchaseRequestItem> PurchaseRequestItems{set;get;} // 請購單項目
}