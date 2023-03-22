using DbLayer;
using Microsoft.Extensions.DependencyInjection;
using WeatherApiService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {

        // Database Context
        //services.AddScoped<DataContext>();
        services.AddSingleton<DBLayerClass>();
        services.AddHostedService<Worker>();
    }).Build();

await host.RunAsync();
