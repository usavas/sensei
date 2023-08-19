using Sensei.Application.Ports;
using Sensei.Domain.MountedSensorFeature;
using Sensei.Domain.SensorDataFeature;

namespace Sensei.Reader;

public class SensorReader : ISensorReader
{
    public async Task<SensorReadData> Read(MountedSensor mountedSensor)
    {
        // read sensor data here

        await Task.Delay(new Random().Next(0, 1000));
        
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