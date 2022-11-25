namespace LayeredArchitecture.Repositories.Models;

public class PartNumber
{
    [Key]
    public string Id{set;get;} // 料號編碼
    public string Name{set;get;} // 名稱
    public string Spec{set;get;} // 規格
}