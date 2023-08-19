using Sensei.Domain.MountedSensorFeature;
using Sensei.Domain.SensorDataFeature;

namespace Sensei.Reader;

public interface ISensorReader
{
    SensorData Read(MountedSensor mountedSensor);
}