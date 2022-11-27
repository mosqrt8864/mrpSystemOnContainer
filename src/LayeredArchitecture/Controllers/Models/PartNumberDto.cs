using LayeredArchitecture.Services.Models;
using LayeredArchitecture.Commons.Mappings;
namespace LayeredArchitecture.Controllers.Models;

public class CreatePartNumberRequest 
{
    public string Id{set;get;} = string.Empty; // 料號編碼
    public string Name{set;get;} = string.Empty; // 名稱
    public string Spec{set;get;} = string.Empty; // 規格
}
public class UpdatePartNumberRequest 
{
    public string Id{set;get;} = string.Empty; // 料號編碼
    public string Name{set;get;} = string.Empty; // 名稱
    public string Spec{set;get;} = string.Empty; // 規格
}

public class GetPartNumberResp :IMapFrom<PartNumberBo>
{
    public string Id{set;get;} = string.Empty; // 料號編碼
    public string Name{set;get;} = string.Empty; // 名稱
    public string Spec{set;get;} = string.Empty; // 規格


    public override bool Equals(Object? obj)
    {
        if (obj == null)
            return false;

        GetPartNumberResp? other = obj as GetPartNumberResp;
        if ((Object?)other == null)
            return false;

        return this.Id == other.Id
            && this.Name == other.Name
            && this.Spec == other.Spec;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
public class GetPartNumberListReq
{
    public int PageSize{set;get;}=1;
    public int PageNumber {set;get;}=10;
}
public class GetPartNumberListResp :IMapFrom<PartNumberBo>
{
    public string Id{set;get;} = string.Empty; // 料號編碼
    public string Name{set;get;} = string.Empty; // 名稱
    public string Spec{set;get;} = string.Empty; // 規格

    public override bool Equals(Object? obj)
    {
        if (obj == null)
            return false;

        GetPartNumberListResp? other = obj as GetPartNumberListResp;
        if ((Object?)other == null)
            return false;

        return this.Id == other.Id
            && this.Name == other.Name
            && this.Spec == other.Spec;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}