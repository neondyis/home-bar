namespace src.Models;

public class Measurement
{
    public int MeasurementId { get; set; }
    public Double Value { get; set; }
    public MeasurementType Type { get; set; }
}