using System.ComponentModel.DataAnnotations.Schema;

namespace src.Models
{
    public class Brand
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandId { get; set; }

        public string BrandName { get; set; }
    }
}
