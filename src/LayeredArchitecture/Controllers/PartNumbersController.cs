using Microsoft.AspNetCore.Mvc;
using LayeredArchitecture.Services.interfaces;
using AutoMapper;
using LayeredArchitecture.Controllers.Models;
using LayeredArchitecture.Services.Models;
namespace LayeredArchitecture.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PartNumbersController : ControllerBase
{
    private IPartNumberService _service;
    private IMapper _mapper;
    private readonly ILogger _logger;
    public PartNumbersController(IPartNumberService service,IMapper mapper,ILogger<PartNumbersController> logger)
    {
        _service = service;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult<bool>> Create(CreatePartNumberRequest request)
    {
        try
        {
            _logger.LogInformation(
                    "----- Sending command: ({@Command})",
                    request);
            // dto to bo
            var partNumberBo = _mapper.Map<PartNumberBo>(request);
            var result = await _service.CreatePartNumber(partNumberBo);
            return result;
        }
        catch(Exception ex)
        {
            _logger.LogError("ErrMsg: {@string} , StatusCode: {code}.",ex.Message.ToString(),500);
            return StatusCode(500);
        }
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<GetPartNumberResp>> Get(string id)
    {
        try
        {
            // bo to dto
            var result =  _mapper.Map<GetPartNumberResp>( await _service.GetPartNumber(id));

            if(result==null)
            {
                return BadRequest();
            }
            return result;
        }
        catch(Exception ex)
        {
            _logger.LogError("ErrMsg: {@string} , StatusCode: {code}.",ex.Message.ToString(),500);
            return StatusCode(500);
        }
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<bool>> Update(string id,CreatePartNumberRequest request)
    {
        try
        {
            request.Id = id;
            _logger.LogInformation(
                    "----- Sending command: ({@Command})",
                    request);
            // dto to bo
            var partNumberBo = _mapper.Map<PartNumberBo>(request);
            return await _service.UpdatePartNumber(partNumberBo);
        }
        catch(Exception ex)
        {
            _logger.LogError("ErrMsg: {@string} , StatusCode: {code}.",ex.Message.ToString(),500);
            return StatusCode(500);
        }
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<GetPartNumberListResp>>>GetList([FromQuery] GetPartNumberListReq request)
    {
        try
        {
            _logger.LogInformation(
                    "----- Sending command: ({@Command})",
                    request);
            var list = await _service.GetPartNumberList(request.PageSize,request.PageNumber);
            // bo to dto
            var partNumberList = _mapper.Map<IEnumerable<GetPartNumberListResp>>( list.Items);
            var result = new PaginatedList<GetPartNumberListResp>(partNumberList,list.Count,request.PageNumber,request.PageSize);
            return result;
        }
        catch(Exception ex)
        {
            _logger.LogError("ErrMsg: {@string} , StatusCode: {code}.",ex.Message.ToString(),500);
            return StatusCode(500);
        }
    }
}