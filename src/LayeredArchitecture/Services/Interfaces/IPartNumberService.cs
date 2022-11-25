using LayeredArchitecture.Services.Models;
namespace LayeredArchitecture.Services.interfaces;

public interface IPartNumberService
{
    Task<bool> CreatePartNumber(PartNumberBo partNumber);
    Task<PartNumberBo> GetPartNumber(string id);
}