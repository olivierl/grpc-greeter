using GrpcGreeter;

namespace GrpcGreeterWorker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly Greeter.GreeterClient _client;

    public Worker(ILogger<Worker> logger, Greeter.GreeterClient client)
    {
        _logger = logger;
        _client = client;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var request = new HelloRequest { Name = "GreeterWorker" };
            var reply = await _client.SayHelloAsync(request, cancellationToken: stoppingToken);
            _logger.LogInformation("[{time}] Greeting: {message}", DateTimeOffset.Now, reply.Message);
            
            await Task.Delay(1000, stoppingToken);
        }
    }
}