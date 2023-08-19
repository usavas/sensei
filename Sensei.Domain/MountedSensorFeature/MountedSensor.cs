namespace Sensei.Domain.MountedSensorFeature;

public class MountedSensor
{
    public int Id { get; set; }
    public string IP { get; set; }
    public int Port { get; set; }
    public string Name { get; set; }
    public SerialNumber SN { get; set; }
}