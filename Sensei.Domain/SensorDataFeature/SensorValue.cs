using Sensei.Domain.Sensor;

namespace Sensei.Domain.SensorDataFeature;

public class SensorValue
{
    public SensorType SensorType { get; set; }
    public string Value { get; set; }
}