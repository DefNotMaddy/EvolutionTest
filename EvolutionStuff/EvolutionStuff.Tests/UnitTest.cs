using EvolutionStuff.ServiceInterface;
using NUnit.Framework;
using ServiceStack;
using ServiceStack.Testing;

namespace EvolutionStuff.Tests;

public class UnitTest
{
    private readonly ServiceStackHost appHost;

    public UnitTest()
    {
        appHost = new BasicAppHost().Init();
        appHost.Container.AddTransient<EvolutionTestService>();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown() => appHost.Dispose();

    [Test]
    public void CanCall()
    {
        //var service = appHost.Container.Resolve<EvolutionTestService>();

        //var response = (HelloResponse)service.Any(new Hello { Name = "World" });

        //Assert.That(response.Result, Is.EqualTo("Hello, World!"));
    }
}