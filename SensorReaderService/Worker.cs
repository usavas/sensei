using MediatR;
using Sensei.Application.RequestHandlers;
using Sensei.Domain.MountedSensorFeature;
using Sensei.Domain.SensorFeature;

namespace SensorReaderService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IMediator _sender;

    public Worker(ILogger<Worker> logger, IMediator mediator)
    {
        _logger = logger;
        _sender = mediator;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        int batchCounter = 1;
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            var sensors = new List<MountedSensor>()
            {
                new MountedSensor()
                {
                    Id = 1,
                    IP = "192.168.1.1",
                    Port = 1453,
                    Name = "Test sensor 1",
                    Sensor = new Sensor()
                    {
                        Type = new SensorType("air")
                    }
                },
                new MountedSensor()
                {
                    Id = 2,
                    IP = "192.168.1.2",
                    Port = 1454,
                    Name = "Test sensor 2",
                    Sensor = new Sensor()
                    {
                        Type = new SensorType("humidity")
                    }
                },
                new MountedSensor()
                {
                    Id = 3,
                    IP = "192.168.1.3",
                    Port = 1455,
                    Name = "Test sensor 3",
                    Sensor = new Sensor()
                    {
                        Type = new SensorType("lock")
                    }
                },
            };

            Task.WhenAll(
                sensors.Select(
                    sensor => _sender.Send(
                        new SensorDataReadCommand(sensor), stoppingToken)).ToArray())
                .ContinueWith((_) =>
                {
                    Console.WriteLine($"Batch {batchCounter++} completed.");
                }, stoppingToken);

            Task.Delay(1000, stoppingToken);
        }

        return Task.CompletedTask;
    }
}