using Newtonsoft.Json;
using WireMock.Admin.Requests;
using WireMock.Logging;

namespace WireMockTemplate;

public class WireMockLogger : IWireMockLogger
{
    private readonly ILogger _logger;
    
    public WireMockLogger(ILogger logger)
    {
        _logger = logger;
    }

    public void Debug(string formatString, params object[] args)
    {
        _logger.Log(LogLevel.Debug, formatString, args);
    }

    public void Info(string formatString, params object[] args)
    {
        _logger.Log(LogLevel.Information, formatString, args);
    }

    public void Warn(string formatString, params object[] args)
    {
        _logger.Log(LogLevel.Warning, formatString, args);
    }

    public void Error(string formatString, params object[] args)
    {
        _logger.Log(LogLevel.Error, formatString, args);
    }

    public void DebugRequestResponse(LogEntryModel logEntryModel, bool isAdminrequest)
    {
        string message = JsonConvert.SerializeObject(logEntryModel, Formatting.Indented);
        _logger.Log(LogLevel.Debug, "Admin[{0}] {1}", isAdminrequest, message);
    }

    public void Error(string formatString, Exception exception)
    {
        _logger.Log(LogLevel.Error, exception, formatString);
    } 
}