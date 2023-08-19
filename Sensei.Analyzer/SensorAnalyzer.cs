using Sensei.Application.Ports;
using Sensei.Domain.SensorDataFeature;

namespace Sensei.Analyzer;

public class SensorAnalyzer : ISensorAnalyzer
{
    public async Task<SensorDataAnalysis> Analyze(SensorReadData sensorReadData)
    {
        await Task.Delay(new Random().Next(0, 1000));
        
        return new SensorDataAnalysis(
            sensorReadData.MountedSensor, 
            $"Analyzed sensor {sensorReadData.MountedSensor.Name} at value: {sensorReadData.SensorValue.Value}");
    }
}