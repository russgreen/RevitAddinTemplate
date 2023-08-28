using Microsoft.Extensions.Logging;

namespace RevitAddinTemplate.Services;
internal class Service : IService
{
    private readonly ILogger<Service> _logger;

    public Service(ILogger<Service> logger)
    {
        _logger = logger;
    }

    public void DoStuff()
    {
        _logger.LogDebug("Doing stuff");
    }
}
