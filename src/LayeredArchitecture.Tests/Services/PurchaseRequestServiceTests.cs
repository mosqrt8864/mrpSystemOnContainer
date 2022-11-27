public class PurchaseRequestServiceTests
{
    private Mock<IPurchaseRequestRepository> _repository;
    private IMapper _mapper;
    private PurchaseRequestService _service;

    [SetUp]
    public void Setup()
    {
        var configuration = new MapperConfiguration(cfg=>{
            cfg.CreateMap<PurchaseRequest,PurchaseRequestBo>();
            cfg.CreateMap<PurchaseRequestBo,PurchaseRequest>();
            cfg.CreateMap<PurchaseRequestItem,PurchaseRequestItemBo>();
            cfg.CreateMap<PurchaseRequestItemBo,PurchaseRequestItem>();
        });
        _mapper = configuration.CreateMapper();
        _repository = new Mock<IPurchaseRequestRepository>();
        _service = new PurchaseRequestService(_repository.Object,_mapper);
    }

    [Test]
    public void CreatePurchaseRequest()
    {
        // Arrange
        var purchaseRequestItem = new List<PurchaseRequestItemBo>(){ 
            new PurchaseRequestItemBo(){Id=1,PRId="Id",PNId="PNId",
            Name="Name",Spec="Spec",Qty=100}};
        var purchaseRequest = new PurchaseRequestBo(){Id="Id",Description="Desc",
            CreateAt=DateTime.Now,PurchaseRequestItems=purchaseRequestItem};

        _repository.Setup(x=>x.Add(It.IsAny<PurchaseRequest>()))
            .ReturnsAsync(true);

        // Act
        var actual = _service.CreatePurchaseRequest(purchaseRequest);

        // Assert
        Assert.IsTrue(actual.Result);
    }

    [Test]
    public void GetPurchaseRequest()
    {
        // Arrange
        var purchaseRequestItem = new List<PurchaseRequestItem>(){ 
            new PurchaseRequestItem(){Id=1,PRId="Id",PNId="PNId",
            Name="Name",Spec="Spec",Qty=100}};
        var purchaseRequest = new PurchaseRequest(){Id="Id",Description="Desc",
            CreateAt=DateTime.Now,PurchaseRequestItems=purchaseRequestItem};
        var expected = _mapper.Map<PurchaseRequestBo>(purchaseRequest);

        _repository.Setup(x=>x.GetAsync(It.IsAny<string>()))
            .ReturnsAsync(purchaseRequest);

        // Act
        var id = "Id";
        var actual = _service.GetPurchaseRequest(id);

        // Assert
        Assert.That(actual.Result,Is.EqualTo(expected));
    }
    [Test]
    public void GetPurchaseRequestList()
    {
        // Arrange
        var purchaseRequest = new PurchaseRequest(){Id="Id",Description="Desc",
            CreateAt=DateTime.Now};
        var purchaseRequestList = new List<PurchaseRequest>(){purchaseRequest};
        var purchaseRequestListBo = _mapper.Map<List<PurchaseRequestBo>>(purchaseRequestList);
        var expected = new PurchaseRequestListBo(){Count = 1,Items = purchaseRequestListBo};

        _repository.Setup(x => x.GetListAsync(It.IsAny<int>(),It.IsAny<int>()))
                    .ReturnsAsync(purchaseRequestList);
        _repository.Setup(x => x.GetCountAsync())
                    .ReturnsAsync(1);
        
        // Act
        int pageSize = 1,pageNumber=10;
        var actual = _service.GetPurchaseRequestList(pageSize,pageNumber);

        // Assert
        Assert.That(actual.Result,Is.EqualTo(expected));
    }
    [Test]
    public void UpdatePurchaseRequest()
    {
        // Arrange
        var purchaseRequestItem = new List<PurchaseRequestItem>(){ 
            new PurchaseRequestItem(){Id=1,PRId="Id",PNId="PNId",
            Name="Name",Spec="Spec",Qty=100}};
        var purchaseRequest = new PurchaseRequest(){Id="Id",Description="Desc",
            CreateAt=DateTime.Now,PurchaseRequestItems=purchaseRequestItem};
        var purchaseRequestBo = _mapper.Map<PurchaseRequestBo>(purchaseRequest);

        _repository.Setup(x=>x.GetAsync(It.IsAny<string>()))
            .ReturnsAsync(purchaseRequest);
        _repository.Setup(x=>x.SaveChangesAsync())
            .ReturnsAsync(true);

        // Act
        var actual = _service.UpdatePurchaseRequest(purchaseRequestBo);

        // Assert
        Assert.IsTrue(actual.Result);
    }
    [Test]
    public void DeletePurchaseRequest()
    {
        // Arrange
        var purchaseRequestItem = new List<PurchaseRequestItem>(){ 
            new PurchaseRequestItem(){Id=1,PRId="Id",PNId="PNId",
            Name="Name",Spec="Spec",Qty=100}};
        var purchaseRequest = new PurchaseRequest(){Id="Id",Description="Desc",
            CreateAt=DateTime.Now,PurchaseRequestItems=purchaseRequestItem};
            
        _repository.Setup(x=>x.GetAsync(It.IsAny<string>()))
            .ReturnsAsync(purchaseRequest);
        _repository.Setup(x=>x.Delete(It.IsAny<PurchaseRequest>()))
            .ReturnsAsync(true);

        // Act
        var id = "Id";
        var actual = _service.DeletePurchaseRequest(id);

        // Assert
        Assert.IsTrue(actual.Result);
    }
}