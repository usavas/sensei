using MediatR;
using Sensei.Domain.SensorDataFeature;

namespace Sensei.Application.Events;

public class SensorDataAnalyzedEvent : INotification
{
    public SensorDataAnalyzedEvent(SensorDataAnalysis sensorDataAnalysis)
    {
        SensorDataAnalysis = sensorDataAnalysis;
    }

    public SensorDataAnalysis SensorDataAnalysis { get; set; }
}