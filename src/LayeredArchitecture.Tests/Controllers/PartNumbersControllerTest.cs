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
        _logger = new Mock<ILogger<PartNumbersController>>();
        _controller = new PartNumbersController(_service.Object,_mapper,_logger.Object);
    }
    [Test]
    public void Create()
    {
        // Arrange
        var request = new CreatePartNumberRequest(){Id="Id",Name="Name",Spec="Spec"};

        _service.Setup(x=>x.CreatePartNumber(It.IsAny<PartNumberBo>()))
            .ReturnsAsync(true);

        // Actual
        var actual = _controller.Create(request);

        // Assert
        Assert.IsTrue(actual.Result.Value);
    }
    [Test]
    public void Get()
    {
        // Arrange
        var request = "Id";
        var expected = new GetPartNumberResp(){Id="Id",Name="Name",Spec="Spec"};

        _service.Setup(x=>x.GetPartNumber(It.IsAny<string>()))
            .ReturnsAsync(new PartNumberBo(){Id="Id",Name="Name",Spec="Spec"});

        // Act
        var actual = _controller.Get(request);

        // Assert
        Assert.That(actual.Result.Value,Is.EqualTo(expected));
    }
    [Test]
    public void Update()
    {
        // Arrange
        var id = "Id";
        var request = new UpdatePartNumberRequest(){Name="Name",Spec="Spec"};

        _service.Setup(x=>x.UpdatePartNumber(It.IsAny<PartNumberBo>()))
            .ReturnsAsync(true);

        // Act
        var actual = _controller.Update(id,request);

        // Assert
        Assert.IsTrue(actual.Result.Value);
    }
    [Test]
    public void GetList()
    {
        // Arrange
        var request = new GetPartNumberListReq(){PageSize=1,PageNumber=10};
        var partNumberBo = new PartNumberBo(){Id="Id",Name="Name",Spec="Spec"};
        var partNumberBoList = new List<PartNumberBo>(){partNumberBo};
        var partNumberListBo = new PartNumberListBo(){Count = 1,Items = partNumberBoList};
        var getPartNumberListResp = _mapper.Map<IEnumerable<GetPartNumberListResp>>(partNumberBoList);
        var expected = new PaginatedList<GetPartNumberListResp>(getPartNumberListResp,1,10,1);
        
        _service.Setup(x=>x.GetPartNumberList(It.IsAny<int>(),It.IsAny<int>()))
            .ReturnsAsync(partNumberListBo);

        // Act    
        var actual = _controller.GetList(request);

        // Assert
        Assert.That(actual.Result.Value,Is.EqualTo(expected));
    }
}