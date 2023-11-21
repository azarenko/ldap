using Gatekeeper.LdapServerLibrary;
using System.Security.Cryptography.X509Certificates;

namespace LdapService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IConfiguration _configuration;

    public Worker(ILogger<Worker> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            LdapServer server = new LdapServer
            {
                Port = 389
            };
            server.RegisterEventListener(new LdapEventListener(_configuration));
            server.RegisterLogger(new ConsoleLogger());
            server.RegisterCertificate(new X509Certificate2(Properties.Resources.example_certificate));
            await server.Start();
        }
    }
}
