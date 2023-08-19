using Sensei.Application.Ports;
using Sensei.Domain.SensorDataFeature;

namespace Sensei.Analyzer;

public class SensorAnalyzer : ISensorAnalyzer
{
    public void Analyze(SensorReadData sensorReadData)
    {
        Console.WriteLine($"No alarm generated for {sensorReadData.MountedSensor.Name} {sensorReadData.SensorValue.Value}");

        // save analysis to db
    }
}