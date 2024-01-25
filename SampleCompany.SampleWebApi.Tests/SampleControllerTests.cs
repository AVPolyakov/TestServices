using System.Threading.Tasks;
using NSubstitute;
using RestEase;
using SampleCompany.SampleWebApi.Services;
using TestServices;
using Xunit;

namespace SampleCompany.SampleWebApi.Tests;

public class SampleControllerTests : IClassFixture<TestApplicationFactory>
{
    private readonly TestApplicationFactory _factory;

    public SampleControllerTests(TestApplicationFactory factory)
    {
        _factory = factory;
    }
    
    [Fact]
    public async Task GetSampleValue_WhenCalledWithoutMocks_ReturnsInitialValue()
    {
        var sampleController = RestClient.For<ISampleController>(_factory.HttpClient);
        
        var sampleValue = await sampleController.GetSampleValue();
        Assert.Equal("Original value", sampleValue);
    }
    
[Fact]
public async Task GetSampleValue_WhenCalledWithMock_ReturnsMockValue()
{
    Service.SetCurrent(Substitute.For<ISampleService>())
        .GetSampleValue().ReturnsForAnyArgs("Mock value");
    
    var sampleController = RestClient.For<ISampleController>(_factory.HttpClient);
    
    var sampleValue = await sampleController.GetSampleValue();
    Assert.Equal("Mock value", sampleValue);
}
}