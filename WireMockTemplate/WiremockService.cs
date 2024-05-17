using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WireMock.Server;
using WireMock.Settings;

namespace WireMockTemplate;

public class WireMockService : IHostedService
{
    private WireMockServer? _server;
    private readonly WireMockServerSettings _settings;
    private readonly ILogger<WireMockService> _logger;

    public WireMockService(ILogger<WireMockService> logger, IOptions<WireMockServerSettings> settings)
    {
        _logger = logger;
        _settings = settings.Value;
        _settings.Logger = new WireMockLogger(logger);
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.Log(LogLevel.Information, "Attempting to start wiremock server with settings: \n\n {ServerSettings} \n", 
            JsonConvert.SerializeObject(_settings, Formatting.Indented));
        _server = WireMockServer.Start(_settings);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.Log(LogLevel.Information, "WireMock.Net server stopping");
        _server?.Stop();
        return Task.CompletedTask;
    }
}