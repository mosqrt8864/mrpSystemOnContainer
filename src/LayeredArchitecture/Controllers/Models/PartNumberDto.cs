using LayeredArchitecture.Services.Models;
using LayeredArchitecture.Commons.Mappings;
namespace LayeredArchitecture.Controllers.Models;

public class CreatePartNumberRequest 
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
}