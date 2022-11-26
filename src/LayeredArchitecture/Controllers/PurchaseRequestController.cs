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
    public async Task<bool> Create(CreatePurchaseRequestReq req)
    {
        _logger.LogInformation(
                    "----- Sending command: ({@Command})",
                    req);
        // dto to bo
        var purchaseRequestBo = _mapper.Map<PurchaseRequestBo>(req);
        var result = await _service.CreatePurchaseRequest(purchaseRequestBo);
        return result;
    }
}