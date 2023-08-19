using Sensei.Domain.MountedSensorFeature;

namespace Sensei.Domain.SensorDataFeature;

public class SensorData
{
    public MountedSensor MountedSensor  { get; set; }
    public DateTime TimeRead { get; set; }
    public SensorValue SensorValue { get; set; }
}