using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VillaRestApi.Models
{
    public class Villa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(150), MinLength(3)]
        public string Name { get; set; }
        public string Details { get; set; }
        public double Rate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string PlotArea { get; set; }
        public string Owner { get; set; }
        public string ImageUrl { get; set; }
        public string Anemity { get; set; } 
    }
}
