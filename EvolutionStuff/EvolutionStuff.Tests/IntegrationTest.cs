using EvolutionStuff.ServiceInterface;
using Funq;
using NUnit.Framework;
using ServiceStack;

namespace EvolutionStuff.Tests;

public class IntegrationTest
{
    const string BaseUri = "http://localhost:2000/";
    private readonly ServiceStackHost appHost;

    class AppHost : AppSelfHostBase
    {
        public AppHost() : base(nameof(IntegrationTest), typeof(EvolutionTestService).Assembly) { }

        public override void Configure(Container container)
        {
        }
    }

    public IntegrationTest()
    {
        appHost = new AppHost()
            .Init()
            .Start(BaseUri);
    }

    [OneTimeTearDown]
    public void OneTimeTearDown() => appHost.Dispose();

    public static IServiceClient CreateClient() => new JsonServiceClient(BaseUri);

    [Test]
    public void Can_call_Hello_Service()
    {
        _ = CreateClient();

        //var response = client.Get(new Hello { Name = "World" });

        //Assert.That(response.Result, Is.EqualTo("Hello, World!"));
    }
}