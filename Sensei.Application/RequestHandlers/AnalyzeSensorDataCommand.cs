using MediatR;
using Sensei.Application.Ports;
using Sensei.Domain.SensorDataFeature;

namespace Sensei.Application.RequestHandlers;

public class AnalyzeSensorDataCommand : IRequest
{
    public readonly SensorReadData SensorReadData;

    public AnalyzeSensorDataCommand(SensorReadData sensorReadData)
    {
        SensorReadData = sensorReadData;
    }
}

public class AnalyzeSensorDataCommandHandler : IRequestHandler<AnalyzeSensorDataCommand>
{
    private readonly ISensorAnalyzer _sensorAnalyzer;

    public AnalyzeSensorDataCommandHandler(ISensorAnalyzer sensorAnalyzer)
    {
        _sensorAnalyzer = sensorAnalyzer;
    }

    public Task Handle(AnalyzeSensorDataCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Sensor Data analyze command received for {request.SensorReadData.MountedSensor.Name}.");
        
        _sensorAnalyzer.Analyze(request.SensorReadData);

        return Task.CompletedTask;
    }
}