using System.Threading.Tasks;
using RestEase;

namespace SampleCompany.SampleWebApi.Tests;

public interface ISampleController
{
    [Get("sample")]
    Task<string> GetSampleValue();
}