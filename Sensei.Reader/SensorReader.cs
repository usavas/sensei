using Sensei.Application.Ports;
using Sensei.Domain.MountedSensorFeature;
using Sensei.Domain.SensorDataFeature;

namespace Sensei.Reader;

public class SensorReader : ISensorReader
{
    public SensorReadData Read(MountedSensor mountedSensor)
    {
        // read sensor data here

        Console.WriteLine($"{mountedSensor.Name}'s Data Read");
        
        return new SensorReadData()
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