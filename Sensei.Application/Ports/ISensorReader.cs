using Sensei.Domain.MountedSensorFeature;
using Sensei.Domain.SensorDataFeature;

namespace Sensei.Application.Ports;

public interface ISensorReader
{
    SensorReadData Read(MountedSensor mountedSensor);
}