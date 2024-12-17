using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class UpdateRegionRequestDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Minimum of 3 characters required")]
        [MaxLength(3, ErrorMessage = "Max 3 characters allowed")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Max 100 characters allowed")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
