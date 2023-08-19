using MediatR;
using Sensei.Domain.SensorDataFeature;

namespace Sensei.Application.Events;

public class SensorDataReadEvent : INotification
{
    public SensorDataReadEvent(SensorReadData sensorReadData)
    {
        SensorReadData = sensorReadData;
    }

    public SensorReadData SensorReadData { get; set; }
}