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
}