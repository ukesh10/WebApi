using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext: DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; } 
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding data for Difficulties - Easy | Medium | Hard
            var difficulties = new List<Difficulty>()
            {
                new Difficulty { Id = Guid.Parse("a3280cfa-e429-48ce-b052-af44284a3598"), Name = "Easy" },
                new Difficulty { Id = Guid.Parse("d8fe1e92-f4a3-4210-b0a8-22aca823ed3f"), Name = "Medium" },
                new Difficulty { Id = Guid.Parse("7a9252a3-f356-413b-a1aa-81469cd17d48"), Name = "Hard" }
            };
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seeding data for Regions
            var regions = new List<Region>()
            {
                new Region { Id = Guid.Parse("7ae15877-29a2-4fca-9c82-75b9f580de52"), Name = "Auckland", Code = "AKL", RegionImageUrl = "demo.jpg" },
                new Region { Id = Guid.Parse("debc0f11-a72b-48a9-bc61-28c12a24f961"), Name = "Northland", Code = "NTL", RegionImageUrl = "demo.jpg" },
                new Region { Id = Guid.Parse("31a9de1e-7ad5-4fc4-b204-d62c6754c8d5"), Name = "Bay of Plenty", Code = "BOP", RegionImageUrl = null },
                new Region { Id = Guid.Parse("481f06e9-37be-4d30-a1f9-c9825b598756"), Name = "Wellington", Code = "WGN", RegionImageUrl = "demo.jpg" },
                new Region { Id = Guid.Parse("1ad1b440-2694-46cb-8f0b-a5ac7e119e41"), Name = "Nelson", Code = "NSN", RegionImageUrl = "demo.jpg" },
                new Region { Id = Guid.Parse("f46b4a38-f4c5-4760-bddc-d0755289351e"), Name = "Southland", Code = "STL", RegionImageUrl = null },
            };
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
