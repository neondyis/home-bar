using System.ComponentModel.DataAnnotations.Schema;

namespace src.Models;

public class MeasurementType
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MeasurementTypeId { get; set; }
    public string Type { get; set; }
}