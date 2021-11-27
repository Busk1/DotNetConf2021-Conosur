// CSharp example

using NBomber.Contracts;
using NBomber.CSharp;
using NBomber.Plugins.Http.CSharp;

var httpFactory = HttpClientFactory.Create();
var tests = new[]
{
    new {
        Name = "net5",
        Url = "https://localhost:5001/weatherforecast"
    },
    new
    {
        Name = "net6",
        Url = "https://localhost:7042/weatherforecast"
    }
};

var scenarios = new List<Scenario>();
foreach (var test in tests)
{
    var step = Step.Create($"step_{test.Name}", httpFactory, async context =>    {
        var response = await context.Client.GetAsync(test.Url, context.CancellationToken);
        return response.IsSuccessStatusCode ? Response.Ok(statusCode: (int)response.StatusCode) : Response.Fail(statusCode: (int)response.StatusCode);
    });

    scenarios.Add(ScenarioBuilder.CreateScenario($"scenario_{test.Name}", step));
}

NBomberRunner
    .RegisterScenarios(scenarios.ToArray())
    .Run();

