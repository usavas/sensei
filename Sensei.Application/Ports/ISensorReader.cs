using Sensei.Domain.MountedSensorFeature;
using Sensei.Domain.SensorDataFeature;

namespace Sensei.Application.Ports;

public interface ISensorReader
{
    SensorData Read(MountedSensor mountedSensor);
}