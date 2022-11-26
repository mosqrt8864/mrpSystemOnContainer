public class PurchaseRequestItemsControllerTest
{
    private Mock<IPurchaseRequestItemService> _service;
    private Mock<ILogger<PurchaseRequestItemsController>> _logger;

    private PurchaseRequestItemsController _controller;
    [SetUp]
    public void Setup()
    {
        _service = new Mock<IPurchaseRequestItemService>();
        _service.Setup(x=>x.DeletePurchaseRequestItem(It.IsAny<int>()))
            .ReturnsAsync(true);
        _logger = new Mock<ILogger<PurchaseRequestItemsController>>();
        _controller = new PurchaseRequestItemsController(_service.Object,_logger.Object);
    }
    [Test]
    public void Delete()
    {
        var id = 1;
        var result= _controller.Delete(id);
        Assert.IsNotNull(result);        
    }
}