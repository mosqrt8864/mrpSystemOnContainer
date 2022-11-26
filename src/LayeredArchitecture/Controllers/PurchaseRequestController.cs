using Microsoft.AspNetCore.Mvc;
using LayeredArchitecture.Services.interfaces;
using AutoMapper;
using LayeredArchitecture.Controllers.Models;
using LayeredArchitecture.Services.Models;
namespace LayeredArchitecture.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PurchaseRequestsController : ControllerBase
{
    private readonly IPurchaseRequestService _service;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    public PurchaseRequestsController(IPurchaseRequestService service,IMapper mapper,ILogger<PartNumbersController> logger)
    {
        _service = service;
        _mapper = mapper;
        _logger = logger;
    }
    [HttpPost]
    public async Task<ActionResult<bool>> Create(CreatePurchaseRequestReq req)
    {
        try
        {
            _logger.LogInformation(
                    "----- Sending command: ({@Command})",
                    req);
            // dto to bo
            var purchaseRequestBo = _mapper.Map<PurchaseRequestBo>(req);
            var result = await _service.CreatePurchaseRequest(purchaseRequestBo);
            return result;
        }
        catch(Exception ex)
        {
            _logger.LogError("ErrMsg: {@string} , StatusCode: {code}.",ex.Message.ToString(),500);
            return StatusCode(500);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetPurchaseRequestResp>> Get (string id)
    {
        try
        {
            // bo to dto
            var result = _mapper.Map<GetPurchaseRequestResp>(await _service.GetPurchaseRequest(id));
            if (result == null)
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

    [HttpGet]
    public async Task<ActionResult<PaginatedList<GetPurchaseRequestListResp>>> GetList([FromQuery] GetPurchaseRequestListReq request)
    {
        var listBo = await _service.GetPurchaseRequestList(request.PageSize,request.PageNumber);
        // bo to dto
        var purchaseRequestList = _mapper.Map<IEnumerable<GetPurchaseRequestListResp>>(listBo.Items);
        return new PaginatedList<GetPurchaseRequestListResp>(purchaseRequestList,listBo.Count,request.PageNumber,request.PageSize);
    }
}