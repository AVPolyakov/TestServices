namespace SampleCompany.SampleWebApi.Services;

public class SampleService : ISampleService
{
    public Task<string> GetSampleValue() => Task.FromResult("Original value");
}