using System.Reflection;
using Sensei.Analyzer;
using Sensei.Application;
using Sensei.Application.Ports;
using Sensei.Reader;
using SensorReaderService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();

        services.AddTransient<ISensorReader, SensorReader>();
        services.AddTransient<ISensorAnalyzer, SensorAnalyzer>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.InjectApplicationDependencies();
    })
    .Build();


host.Run();