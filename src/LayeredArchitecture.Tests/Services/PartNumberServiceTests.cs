namespace LayeredArchitecture.Tests.Services;

public class PartNumberServiceTests
{
    private Mock<IPartNumberRepository> _reposiory;
    private IMapper _mapper;
    private PartNumberService _service;
    [SetUp]
    public void Setup()
    {
        var configuration = new MapperConfiguration(cfg =>{
            cfg.CreateMap<PartNumberBo, PartNumber>();
            cfg.CreateMap<PartNumber, PartNumberBo>();
        });
        _mapper = configuration.CreateMapper();
        _reposiory = new Mock<IPartNumberRepository>();
        _reposiory.Setup(x => x.Add(It.IsAny<PartNumber>()));
        _reposiory.Setup(x => x.GetAsync(It.IsAny<string>()))
                    .ReturnsAsync(new PartNumber() { Id="Id",Name="Name",Spec="Spec"});
        _reposiory.Setup(x => x.GetListAsync(It.IsAny<int>(),It.IsAny<int>()))
                    .ReturnsAsync(new List<PartNumber>(){new PartNumber(){Id="Id",Name="Name",Spec="Spec"},
                    new PartNumber(){Id="Id",Name="Name",Spec="Spec"}});
        _reposiory.Setup(x=>x.GetCountAsync())
                    .ReturnsAsync(2);
        _service = new PartNumberService(_reposiory.Object,_mapper);
    }

    [Test]
    public void CreatePartNumber()
    {

        var result = _service.CreatePartNumber(new PartNumberBo(){Id="Id",Name="Name",Spec="Spec"});
        Assert.IsTrue(result.Result);
    }
    [Test]

    public void GetPartNumber()
    {
        var id = "Id";
        var result = _service.GetPartNumber(id);
        Assert.IsTrue(result.Result.Id == id);
    }

    [Test]
    public void GetPartNumberList()
    {
        int pageSize = 1,pageNumber=10;
        var result = _service.GetPartNumberList(pageSize,pageNumber);
        Assert.IsTrue(result.Result.Count == 2); 
    }
    [Test]
    public void UpdatePartNumber()
    {
        var result = _service.UpdatePartNumber(new PartNumberBo(){Id="Id",Name="Name",Spec="Spec"});
        Assert.IsTrue(result.Result);
    }
}