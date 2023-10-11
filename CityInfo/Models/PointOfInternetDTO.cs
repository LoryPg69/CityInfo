using System.ComponentModel.DataAnnotations;

namespace CityInfo.Models
{
    public class PointOfInternetDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(50)]
        public string? Description { get; set; }
    }
}
