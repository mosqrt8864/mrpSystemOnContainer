public class PurchaseRequestItemServiceTests
{
    private Mock<IPurchaseRequestItemRepository> _repository;
    private PurchaseRequestItemService _service;
    [SetUp]
    public void Setup()
    {
        _repository = new Mock<IPurchaseRequestItemRepository>();
        _service = new PurchaseRequestItemService(_repository.Object);
    }

    [Test]
    public void DeletePurchaseRequestItem()
    {
        // Arrange
        var purchaseRequestItem = new PurchaseRequestItem(){Id=1,PRId="Id",PNId="PNId",
            Name="Name",Spec="Spec",Qty=100};
            
        _repository.Setup(x=>x.GetAsync(It.IsAny<int>()))
            .ReturnsAsync(purchaseRequestItem);
        _repository.Setup(x=>x.Delete(It.IsAny<PurchaseRequestItem>()))
            .ReturnsAsync(true);

        // Act
        var id = 1;
        var actual = _service.DeletePurchaseRequestItem(id);

        // Assert
        Assert.IsTrue(actual.Result);
    }
}