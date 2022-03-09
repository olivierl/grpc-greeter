using GrpcGreeter;
using GrpcGreeterWorker;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var config = context.Configuration;

        services.AddGrpcClient<Greeter.GreeterClient>(o => { o.Address = new Uri(config["GREETER_SERVICE_HOST"]); });
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();