public class PurchaseRequestItemServiceTests
{
    private Mock<IPurchaseRequestItemRepository> _repository;
    private PurchaseRequestItemService _service;
    [SetUp]
    public void Setup()
    {
        _repository = new Mock<IPurchaseRequestItemRepository>();
        _repository.Setup(x=>x.Delete(It.IsAny<PurchaseRequestItem>()));
        _service = new PurchaseRequestItemService(_repository.Object);
    }

    [Test]
    public void DeletePurchaseRequestItem()
    {
        var id = 1;
        var result = _service.DeletePurchaseRequestItem(id);
        Assert.IsTrue(result.Result);
    }
}