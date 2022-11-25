namespace WebMVC.ViewModels.PurchaseRequest.Detail;
public class DetailPurchaseRequestViewModel{
    public DetailPurchaseRequestViewModel()
    {
        PurchaseRequestItems = new List<DetailPurchaseRequestItemViewModel>();
    }
    public string Id{set;get;} = string.Empty;
    public string Description{set;get;} = string.Empty;

    public DateTime CreateAt{set;get;}
    public List<DetailPurchaseRequestItemViewModel> PurchaseRequestItems{set;get;}
}

public class DetailPurchaseRequestItemViewModel
{
    public int Id {set;get;} = 0;
    public string PRId {set;get;} = string.Empty;
    public string PNId{set;get;} = string.Empty;
    public string Name{set;get;} = string.Empty;
    public string Spec{set;get;} = string.Empty;
    public int Qty{set;get;} = 1;
}