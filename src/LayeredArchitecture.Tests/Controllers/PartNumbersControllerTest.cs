public class PartNumbersControllerTest
{
    private Mock<IPartNumberService> _service;
    private IMapper _mapper;
    private Mock<ILogger<PartNumbersController>> _logger;
    private PartNumbersController _controller;
    [SetUp]
    public void Setup()
    {
        var configuration = new MapperConfiguration(cfg=>{
            cfg.CreateMap<CreatePartNumberRequest,PartNumberBo>();
            cfg.CreateMap<PartNumberBo,GetPartNumberResp>();
            cfg.CreateMap<UpdatePartNumberRequest,PartNumberBo>();
            cfg.CreateMap<PartNumberBo,GetPartNumberListResp>();
        });
        _mapper = configuration.CreateMapper();
        _service = new Mock<IPartNumberService>();
        _service.Setup(x=>x.CreatePartNumber(It.IsAny<PartNumberBo>()))
            .ReturnsAsync(true);
        _service.Setup(x=>x.UpdatePartNumber(It.IsAny<PartNumberBo>()))
            .ReturnsAsync(true);
        _service.Setup(x=>x.GetPartNumber(It.IsAny<string>()))
            .ReturnsAsync(new PartNumberBo(){Id="Id",Name="Name",Spec="Spec"});
        _service.Setup(x=>x.GetPartNumberList(It.IsAny<int>(),It.IsAny<int>()))
            .ReturnsAsync(new PartNumberListBo(){Items = new List<PartNumberBo>(){new PartNumberBo(){Id="Id",Name="Spec",Spec="Spec"}}
            ,Count = 2});
        _logger = new Mock<ILogger<PartNumbersController>>();
        _controller = new PartNumbersController(_service.Object,_mapper,_logger.Object);

    }
    [Test]
    public void Create()
    {
        var result = _controller.Create(new CreatePartNumberRequest());
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
    public void Update()
    {
        var id = "Id";
        var result = _controller.Update(id,new UpdatePartNumberRequest());
        Assert.IsNotNull(result);
    }
    [Test]
    public void GetList()
    {
        var result = _controller.GetList(new GetPartNumberListReq(){PageSize=1,PageNumber=10});
        Assert.IsNotNull(result);
    }
}