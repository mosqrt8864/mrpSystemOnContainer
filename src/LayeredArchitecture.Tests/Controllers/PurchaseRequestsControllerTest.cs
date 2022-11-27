public class PurchaseRequestsControllerTest
{
    private Mock<IPurchaseRequestService> _service;
    private IMapper _mapper;
    private Mock<ILogger<PurchaseRequestsController>> _logger;
    private PurchaseRequestsController _controller;
    [SetUp]
    public void Setup()
    {
        _service = new Mock<IPurchaseRequestService>();
        _logger = new Mock<ILogger<PurchaseRequestsController>>();
        var configuration = new MapperConfiguration(cfg=>{
            cfg.CreateMap<CreatePurchaseRequestReq,PurchaseRequestBo>();
            cfg.CreateMap<PurchaseRequestBo,GetPurchaseRequestResp>();
            cfg.CreateMap<PurchaseRequestItemBo,GetPurchaseRequestItemResp>();
            cfg.CreateMap<UpdatePurchaseRequestReq,PurchaseRequestBo>();
            cfg.CreateMap<PurchaseRequestBo,GetPurchaseRequestListResp>();
            cfg.CreateMap<CreatePurchaseRequestItemReq,PurchaseRequestItemBo>();
            cfg.CreateMap<UpdatePurchaseRequestItemReq,PurchaseRequestItemBo>();
        });
        _mapper = configuration.CreateMapper();
        _controller = new PurchaseRequestsController(_service.Object,_mapper,_logger.Object);
    }
    [Test]
    public void Create()
    {
        // Arrange
        var item = new CreatePurchaseRequestItemReq(){PNId="PN",PRId="Id",Name="Name",Spec="Spec",Qty=100};
        var itemList = new List<CreatePurchaseRequestItemReq>(){item};
        var request = new CreatePurchaseRequestReq(){Id="Id",Description="Des",
            CreateAt=new DateTime(2022, 11, 1, 0, 0, 0),PurchaseRequestItems=itemList};

        _service.Setup(x=>x.CreatePurchaseRequest(It.IsAny<PurchaseRequestBo>()))
            .ReturnsAsync(true);

        // Act
        var actual = _controller.Create(request);

        // Assert
        Assert.IsTrue(actual.Result.Value);
    }
    [Test]
    public void Get()
    {
        // Arrange
        var item = new PurchaseRequestItemBo(){PNId="PN",PRId="Id",Name="Name",Spec="Spec",Qty=100};
        var itemList = new List<PurchaseRequestItemBo>(){item};
        var purchaseRequest = new PurchaseRequestBo(){Id="Id",Description="Des",
        CreateAt=new DateTime(2022, 11, 1, 0, 0, 0),PurchaseRequestItems=itemList};
        var expected = _mapper.Map<GetPurchaseRequestResp>(purchaseRequest);

        _service.Setup(x=>x.GetPurchaseRequest(It.IsAny<string>()))
            .ReturnsAsync(purchaseRequest);

        // Act
        var id = "Id";
        var actual = _controller.Get(id);

        // Assert
        Assert.That(actual.Result.Value,Is.EqualTo(expected));
    }
    [Test]
    public void GetList()
    {
        // Arrange
        var request = new GetPurchaseRequestListReq(){PageSize=1,PageNumber=10};
        var purchaseRequest = new PurchaseRequestBo(){Id="Id",Description="Des",
        CreateAt=new DateTime(2022, 11, 1, 0, 0, 0)};
        var itemList = new List<PurchaseRequestBo>(){purchaseRequest};
        var list = new PurchaseRequestListBo(){Count=1,Items=itemList};
        var listResp = _mapper.Map<IEnumerable<GetPurchaseRequestListResp>>(itemList);
        var expected = new PaginatedList<GetPurchaseRequestListResp>(listResp,1,10,1);

        _service.Setup(x=>x.GetPurchaseRequestList(It.IsAny<int>(),It.IsAny<int>()))
            .ReturnsAsync(list);

        // Act
        var actual = _controller.GetList(request);

        // Assert
        Assert.That(actual.Result.Value,Is.EqualTo(expected));
    }
    [Test]
    public void Update()
    {
        // Arrange
        var item = new UpdatePurchaseRequestItemReq(){PNId="PN",PRId="Id",Name="Name",Spec="Spec",Qty=100};
        var itemList = new List<UpdatePurchaseRequestItemReq>(){item};
        var reqeust = new UpdatePurchaseRequestReq(){Id="Id",Description="Desc",
        CreateAt=new DateTime(2022, 11, 1, 0, 0, 0),PurchaseRequestItems=itemList};

        _service.Setup(x=>x.UpdatePurchaseRequest(It.IsAny<PurchaseRequestBo>()))
            .ReturnsAsync(true);
        
        // Act
        var id = "Id";
        var actual = _controller.Update(id,reqeust);
        
        // Assert
        Assert.IsTrue(actual.Result.Value);
    }
    [Test]
    public void Delete()
    {
        // Arrange
        _service.Setup(x=>x.DeletePurchaseRequest(It.IsAny<string>()))
            .ReturnsAsync(true);

        // Act
        var id = "Id";
        var actual = _controller.Delete(id);

        // Assert
        Assert.IsTrue(actual.Result.Value);
    }
}