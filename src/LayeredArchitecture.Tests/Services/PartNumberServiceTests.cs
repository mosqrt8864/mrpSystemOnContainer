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
        _service = new PartNumberService(_reposiory.Object,_mapper);
    }

    [Test]
    public void CreatePartNumber()
    {
        // Arrange
        var partNumber = new PartNumberBo(){Id="Id",Name="Name",Spec="Spec"};

        _reposiory.Setup(x=>x.Add(It.IsAny<PartNumber>()))
            .ReturnsAsync(true);
        
        // Act
        var actual = _service.CreatePartNumber(partNumber);

        // Assert
        Assert.IsTrue(actual.Result);
    }
    [Test]

    public void GetPartNumber()
    {
        // Arrange
        var partNumber = new PartNumber(){Id="Id",Name="Name",Spec="Spec"};
        var expected = _mapper.Map<PartNumberBo>(partNumber);

        _reposiory.Setup(x => x.GetAsync(It.IsAny<string>()))
                    .ReturnsAsync(partNumber);

        // Act
        var id = "Id";
        var actual = _service.GetPartNumber(id);

        // Assert
        Assert.That(actual.Result,Is.EqualTo(expected));
    }

    [Test]
    public void GetPartNumberList()
    {
        // Arrange
        var partNumber = new PartNumber(){Id="Id",Name="Name",Spec="Spec"};
        var partNumberList = new List<PartNumber>(){partNumber};
        var partNumberListBo = _mapper.Map<IEnumerable<PartNumberBo>>(partNumberList);
        var expected = new PartNumberListBo(){Count = 1,Items = partNumberListBo};
        
        _reposiory.Setup(x => x.GetListAsync(It.IsAny<int>(),It.IsAny<int>()))
                    .ReturnsAsync(partNumberList);
        _reposiory.Setup(x=>x.GetCountAsync())
                    .ReturnsAsync(1);

        // Act
        int pageSize = 1,pageNumber=10;
        var actual = _service.GetPartNumberList(pageSize,pageNumber);

        // Assert
        Assert.That(actual.Result,Is.EqualTo(expected));
    }
    [Test]
    public void UpdatePartNumber()
    {
        // Arrange
        var partNumber = new PartNumber(){Id="Id",Name="Name",Spec="Spec"};
        var partNumberBo = _mapper.Map<PartNumberBo>(partNumber);

        _reposiory.Setup(x => x.GetAsync(It.IsAny<string>()))
                    .ReturnsAsync(partNumber);
        _reposiory.Setup(x=>x.SaveChangesAsync())
            .ReturnsAsync(true);

        // Act
        var actual = _service.UpdatePartNumber(partNumberBo);

        // Assert
        Assert.IsTrue(actual.Result);
    }
}