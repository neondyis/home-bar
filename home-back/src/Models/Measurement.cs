using System.ComponentModel.DataAnnotations.Schema;

namespace src.Models;

public class Measurement
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MeasurementId { get; set; }
    public Double Value { get; set; }
    
    public int MeasurementTypeId { get; set; }
    public MeasurementType? Type { get; set; }
}