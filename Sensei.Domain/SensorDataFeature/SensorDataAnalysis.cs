using Sensei.Domain.MountedSensorFeature;

namespace Sensei.Domain.SensorDataFeature;

public class SensorDataAnalysis
{
    public SensorDataAnalysis(MountedSensor sensor, string result)
    {
        Result = result;
        Sensor = sensor;
    }

    public string Result { get; set; }
    public MountedSensor Sensor { get; set; }
}