using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class UpdateWalkRequestDTO
    {
        [Required]
        [MaxLength(200, ErrorMessage = "Maximum 200 characters allowed")]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000, ErrorMessage = "Maximum 1000 characters allowed")]
        public string Description { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Length cannot exceed 100 km.")]
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        [Required]
        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }
    }
}
