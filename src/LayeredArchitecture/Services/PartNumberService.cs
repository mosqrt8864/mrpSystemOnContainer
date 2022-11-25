using LayeredArchitecture.Services.interfaces;
using LayeredArchitecture.Services.Models;
using LayeredArchitecture.Repositories.Models;
using LayeredArchitecture.Repositories.interfaces;
using AutoMapper;

namespace LayeredArchitecture.Services;

public class PartNumberService : IPartNumberService
{
    private readonly IPartNumberRepository _reposiory;
    private readonly IMapper _mapper;
    public PartNumberService(IPartNumberRepository repository,IMapper mapper)
    {
        _reposiory = repository;
        _mapper = mapper;
    }
    public async Task<bool> CreatePartNumber(PartNumberBo partNumber)
    {
        // business logic

        // automappet bo to po
        var partNumberPO = _mapper.Map<PartNumber>(partNumber);
        await _reposiory.Add(partNumberPO);
        return true;
    }
    public async Task<PartNumberBo> GetPartNumber(string id)
    {
        var partNumber = await _reposiory.GetAsync(id);
        var partNumberBo = _mapper.Map<PartNumberBo>(partNumber);
        return partNumberBo;
    }

    public async Task<bool> UpdatePartNumber(PartNumberBo partNumber)
    {
        var partNumberPo = await _reposiory.GetAsync(partNumber.Id);
        partNumberPo.Name = partNumber.Name;
        partNumberPo.Spec = partNumber.Spec;
        await _reposiory.SaveChangesAsync();
        return true;
    }
}