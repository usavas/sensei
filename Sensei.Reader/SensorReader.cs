using Sensei.Application.Ports;
using Sensei.Domain.MountedSensorFeature;
using Sensei.Domain.SensorDataFeature;

namespace Sensei.Reader;

public class SensorReader : ISensorReader
{
    public SensorData Read(MountedSensor mountedSensor)
    {
        // dummy logic
        return new SensorData()
        {
            SensorValue = new SensorValue()
            {
                Value = new Random().Next(0, 100).ToString(),
                SensorType = mountedSensor.Sensor.Type,
            },
            MountedSensor = mountedSensor,
            TimeRead = DateTime.Now,
        };
    }
}