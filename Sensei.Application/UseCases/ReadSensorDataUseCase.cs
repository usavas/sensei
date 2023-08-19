using MediatR;
using Sensei.Application.Events;
using Sensei.Application.Ports;
using Sensei.Domain.MountedSensorFeature;
using Sensei.Domain.SensorDataFeature;

namespace Sensei.Application.UseCases;

public class ReadSensorDataUseCase
{
    private readonly ISensorReader _sensorReader;
    private readonly IMediator _mediatr;

    public ReadSensorDataUseCase(ISensorReader sensorReader, IMediator mediatr)
    {
        _sensorReader = sensorReader;
        _mediatr = mediatr;
    }

    public void Handle(MountedSensor mountedSensor)
    {
        Console.WriteLine($"Sensor Data Read request received for {mountedSensor.Name}");
        SensorReadData readReadData = _sensorReader.Read(mountedSensor);

        _mediatr.Publish(new SensorDataReadEvent(readReadData));
    }
}