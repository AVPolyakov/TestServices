using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using TestServices;

namespace SampleCompany.SampleWebApi.Tests;

public class TestApplicationFactory : WebApplicationFactory<Program>
{
    public HttpClient HttpClient { get; }

    public TestApplicationFactory()
    {
        Server.PreserveExecutionContext = true;
        
        HttpClient = CreateClient();
    }
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.DecorateByTestServices(IsFromOurAssemblies);
        });
    }
    
    private static bool IsFromOurAssemblies(Type type)
    {
        return type.Assembly.GetName().Name?.StartsWith("SampleCompany.") == true;
    }
}