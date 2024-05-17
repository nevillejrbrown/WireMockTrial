﻿using WireMock.Settings;

namespace WireMockTemplate;

public static class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
        => Host.CreateDefaultBuilder(args)
            .ConfigureServices((host, services) => ConfigureServices(services, host.Configuration));

    private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddLogging(logging => logging.AddConsole().AddDebug());
        services.Configure<WireMockServerSettings>(configuration.GetSection("WireMockServerSettings"));
        services.AddHostedService<WireMockService>();
    }
}