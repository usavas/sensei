using Sensei.Domain.SensorDataFeature;

namespace Sensei.Application.Ports;

public interface ISensorAnalyzer
{
    void Analyze(SensorReadData sensorReadData);
}