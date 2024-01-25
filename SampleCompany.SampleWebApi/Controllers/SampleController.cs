using Microsoft.AspNetCore.Mvc;
using SampleCompany.SampleWebApi.Services;

namespace SampleCompany.SampleWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SampleController : ControllerBase
{
    private readonly ISampleService _sampleService;

    public SampleController(ISampleService sampleService)
    {
        _sampleService = sampleService;
    }

    [HttpGet]
    public Task<string> GetSampleValue() => _sampleService.GetSampleValue();
}