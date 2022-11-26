using Microsoft.AspNetCore.Mvc;
using LayeredArchitecture.Services.interfaces;
using LayeredArchitecture.Controllers.Models;
using LayeredArchitecture.Services.Models;
namespace LayeredArchitecture.Controllers;

[ApiController]
[Route("api/v1/[controller]")]

public class PurchaseRequestItemsController : ControllerBase
{
    private readonly IPurchaseRequestItemService _service;
    private readonly ILogger _logger;
    public PurchaseRequestItemsController(IPurchaseRequestItemService service,ILogger<PurchaseRequestItemsController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        return await _service.DeletePurchaseRequestItem(id);
    }
}