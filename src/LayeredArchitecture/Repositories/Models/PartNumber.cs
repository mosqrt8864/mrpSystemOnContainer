using System.ComponentModel.DataAnnotations;
namespace LayeredArchitecture.Repositories.Models;

public class PartNumber
{
    [Key]
    public string Id{set;get;} = string.Empty; // 料號編碼
    public string Name{set;get;} = string.Empty; // 名稱
    public string Spec{set;get;} = string.Empty; // 規格
}