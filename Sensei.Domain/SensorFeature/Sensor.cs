namespace Sensei.Domain.Sensor;

public class Sensor
{
    public int Id { get; set; }
    public Producer Producer { get; set; }
    public Brand Brand { get; set; }
    public Model Model { get; set; }
    public SensorType Type { get; set; }
}