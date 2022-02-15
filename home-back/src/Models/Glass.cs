using System.ComponentModel.DataAnnotations.Schema;

namespace src.Models
{
    public class Glass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GlassId { get; set; }
        
        public string Name { get; set; }
    }
}
