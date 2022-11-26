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
        _service.Setup(x=>x.CreatePurchaseRequest(It.IsAny<PurchaseRequestBo>()))
            .ReturnsAsync(true);
        _service.Setup(x=>x.UpdatePurchaseRequest(It.IsAny<PurchaseRequestBo>()))
            .ReturnsAsync(true);
        _service.Setup(x=>x.GetPurchaseRequest(It.IsAny<string>()))
            .ReturnsAsync(new PurchaseRequestBo(){Id = "Id",Description="Desc",CreateAt=DateTime.Now,
                PurchaseRequestItems=new List<PurchaseRequestItemBo>{new PurchaseRequestItemBo(){
                    Id=1,PNId="Pants",PRId="Id",Name="Name",Spec="Spec",Qty=1}}});
        _service.Setup(x=>x.GetPurchaseRequestList(It.IsAny<int>(),It.IsAny<int>()))
            .ReturnsAsync(new PurchaseRequestListBo(){Items=new List<PurchaseRequestBo>(){
                new PurchaseRequestBo(){Id="Id",Description="Desc",CreateAt=DateTime.Now}
            }, Count = 1});
        _service.Setup(x=>x.DeletePurchaseRequest(It.IsAny<string>()))
            .ReturnsAsync(true);
        _logger = new Mock<ILogger<PurchaseRequestsController>>();
        var configuration = new MapperConfiguration(cfg=>{
            cfg.CreateMap<CreatePurchaseRequestReq,PurchaseRequestBo>();
            cfg.CreateMap<PurchaseRequestBo,GetPurchaseRequestResp>();
            cfg.CreateMap<UpdatePurchaseRequestReq,PurchaseRequestBo>();
            cfg.CreateMap<PurchaseRequestBo,GetPurchaseRequestListResp>();
        });
        _mapper = configuration.CreateMapper();
        _controller = new PurchaseRequestsController(_service.Object,_mapper,_logger.Object);
    }
    [Test]
    public void Create()
    {
        var result = _controller.Create(new CreatePurchaseRequestReq());
        Assert.IsNotNull(result);
    }
    [Test]
    public void Get()
    {
        var id = "Id";
        var result = _controller.Get(id);
        Assert.IsNotNull(result);
    }
    [Test]
    public void GetList()
    {
        var result = _controller.GetList(new GetPurchaseRequestListReq(){PageSize=1,PageNumber=10});
        Assert.IsNotNull(result);
    }
    [Test]
    public void Update()
    {
        var id = "Id";
        var result = _controller.Update(id,new UpdatePurchaseRequestReq());
        Assert.IsNotNull(result);
    }
    [Test]
    public void Delete()
    {
        var id = "Id";
        var result = _controller.Delete(id);
        Assert.IsNotNull(result);
    }
}