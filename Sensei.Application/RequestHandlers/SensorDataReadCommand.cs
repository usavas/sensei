using MediatR;
using Sensei.Application.Events;
using Sensei.Application.Ports;
using Sensei.Domain.MountedSensorFeature;
using Sensei.Domain.SensorDataFeature;

namespace Sensei.Application.RequestHandlers;

public class SensorDataReadCommand : IRequest
{
    public SensorDataReadCommand(MountedSensor mountedSensor)
    {
        MountedSensor = mountedSensor;
    }

    public MountedSensor MountedSensor { get; set; }
}

public class SensorDataReadCommandHandler : IRequestHandler<SensorDataReadCommand>
{
    private readonly ISensorReader _sensorReader;
    private readonly IMediator _mediatr;


    public SensorDataReadCommandHandler(ISensorReader sensorReader, IMediator mediatr)
    {
        _sensorReader = sensorReader;
        _mediatr = mediatr;
    }

    public async Task Handle(SensorDataReadCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Sensor Data Read request received for {request.MountedSensor.Name}");
        SensorReadData readReadData = await _sensorReader.Read(request.MountedSensor);

        await _mediatr.Publish(new SensorDataReadEvent(readReadData), cancellationToken);
    }
}