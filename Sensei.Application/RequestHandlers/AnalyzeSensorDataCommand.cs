using MediatR;
using Sensei.Application.Events;
using Sensei.Application.Ports;
using Sensei.Domain.SensorDataFeature;

namespace Sensei.Application.RequestHandlers;

internal class AnalyzeSensorDataCommand : IRequest
{
    public readonly SensorReadData SensorReadData;

    public AnalyzeSensorDataCommand(SensorReadData sensorReadData)
    {
        SensorReadData = sensorReadData;
    }
}

internal class AnalyzeSensorDataCommandHandler : IRequestHandler<AnalyzeSensorDataCommand>
{
    private readonly ISensorAnalyzer _sensorAnalyzer;
    private readonly IMediator _mediator;

    public AnalyzeSensorDataCommandHandler(ISensorAnalyzer sensorAnalyzer, IMediator mediator)
    {
        _sensorAnalyzer = sensorAnalyzer;
        _mediator = mediator;
    }

    public async Task Handle(AnalyzeSensorDataCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Sensor Data analyze command received for {request.SensorReadData.MountedSensor.Name}.");
        
        var analysisResult = await _sensorAnalyzer.Analyze(request.SensorReadData);

        await _mediator.Publish(new SensorDataAnalyzedEvent(
            new SensorDataAnalysis(
                request.SensorReadData.MountedSensor,
                analysisResult.Result)), 
            cancellationToken);
    }
}