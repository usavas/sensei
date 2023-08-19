using Sensei.Domain.SensorDataFeature;

namespace Sensei.Application.Ports;

public interface ISensorAnalyzer
{
    Task<SensorDataAnalysis> Analyze(SensorReadData sensorReadData);
}