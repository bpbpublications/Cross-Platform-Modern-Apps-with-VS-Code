using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service_Ex;

using IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options =>
    {
        options.ServiceName = "Cat Fact Service";
    })
    .ConfigureServices(services =>
    {
        services.AddHostedService<CatBackgroundService>();
        services.AddHttpClient<CatService>();
    })
    .Build();

await host.RunAsync();