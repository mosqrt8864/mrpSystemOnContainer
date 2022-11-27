using LayeredArchitecture.Commons.Mappings;
using LayeredArchitecture.Controllers.Models;
using LayeredArchitecture.Repositories.Models;

namespace LayeredArchitecture.Services.Models;

public class PartNumberBo :IMapFrom<CreatePartNumberRequest>,IMapFrom<PartNumber>,IMapFrom<UpdatePartNumberRequest>
{
    public string Id{set;get;} = string.Empty; // 料號編碼
    public string Name{set;get;} = string.Empty; // 名稱
    public string Spec{set;get;} = string.Empty; // 規格

    public override bool Equals(Object? obj)
    {
        if (obj == null)
            return false;

        PartNumberBo? other = obj as PartNumberBo;
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

public class PartNumberListBo
{
    public IEnumerable<PartNumberBo> Items{set;get;} = new List<PartNumberBo>();
    public int Count{set;get;}

    public override bool Equals(Object? obj)
    {
        if (obj == null)
            return false;

        PartNumberListBo? other = obj as PartNumberListBo;
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