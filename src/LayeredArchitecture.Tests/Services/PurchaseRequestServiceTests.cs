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
        });
        _mapper = configuration.CreateMapper();
        _repository = new Mock<IPurchaseRequestRepository>();
        _repository.Setup(x=>x.Add(It.IsAny<PurchaseRequest>()));
        _repository.Setup(x=>x.SaveChangesAsync());
        _repository.Setup(x=>x.GetAsync(It.IsAny<string>()))
            .ReturnsAsync(new PurchaseRequest(){Id="Id",Description="Des",CreateAt=DateTime.Now,
                PurchaseRequestItems= new List<PurchaseRequestItem>(){new PurchaseRequestItem()
                {Id=1,PRId="Id",PNId="Pants01",Name="Pants",Spec="Block",Qty=100}}});
        _repository.Setup(x => x.GetListAsync(It.IsAny<int>(),It.IsAny<int>()))
                    .ReturnsAsync(new List<PurchaseRequest>(){new PurchaseRequest(){Id="Id",Description="Des",CreateAt=DateTime.Now},
                    new PurchaseRequest(){Id="Id1",Description="Des",CreateAt=DateTime.Now}});
        _repository.Setup(x => x.GetCountAsync())
                    .ReturnsAsync(2);
        _repository.Setup(x=>x.Delete(It.IsAny<PurchaseRequest>()));
        _service = new PurchaseRequestService(_repository.Object,_mapper);
    }

    [Test]
    public void CreatePurchaseRequest()
    {
        var result = _service.CreatePurchaseRequest(new PurchaseRequestBo());
        Assert.IsTrue(result.Result);
    }

    [Test]
    public void GetPurchaseRequest()
    {
        var id = "Id";
        var result = _service.GetPurchaseRequest(id);
        Assert.IsTrue(result.Result.Id == id);
        Assert.IsTrue(result.Result.PurchaseRequestItems.Count == 1);
    }
    [Test]
    public void GetPurchaseRequestList()
    {
        int pageSize = 1,pageNumber=10;
        var result = _service.GetPurchaseRequestList(pageSize,pageNumber);
        Assert.IsTrue(result.Result.Count == 2); 
    }
    [Test]
    public void UpdatePurchaseRequest()
    {
        var result = _service.UpdatePurchaseRequest(new PurchaseRequestBo(){
                Id="Id",Description="Des1",CreateAt=DateTime.Now,
                PurchaseRequestItems= new List<PurchaseRequestItemBo>(){new PurchaseRequestItemBo()
                {Id=1,PRId="Id",PNId="Pants01",Name="Pants",Spec="Block",Qty=100}}});
        Assert.IsTrue(result.Result);
    }
    [Test]
    public void DeletePurchaseRequest()
    {
        var id = "Id";
        var result = _service.DeletePurchaseRequest(id);
        Assert.IsTrue(result.Result);
    }
}