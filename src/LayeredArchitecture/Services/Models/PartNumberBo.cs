using LayeredArchitecture.Commons.Mappings;
using LayeredArchitecture.Controllers.Models;

namespace LayeredArchitecture.Services.Models;

public class PartNumberBo :IMapFrom<CreatePartNumberRequest>
{
    public string Id{set;get;} = string.Empty; // 料號編碼
    public string Name{set;get;} = string.Empty; // 名稱
    public string Spec{set;get;} = string.Empty; // 規格
}