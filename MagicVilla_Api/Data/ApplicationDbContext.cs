using MagicVilla_Api.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MagicVilla_Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Villa> Villas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id=12345,
                    Name = "Villa Sousse",  
                    Description = "Description villa Sousse",
                    NbRoom=3,
                    Superficie=300,
                    ImageUrl= "https://cdn.pixabay.com/photo/2017/09/17/18/15/lost-places-2759275_960_720.jpg",
                    Rate=5.3,
                    Created_date=DateTime.Now
                },
                new Villa()
                {
                    Id = 12344,
                    Name = "Villa Tunis",  
                    Description = "Description villa Tunis",
                    NbRoom = 3,
                    Superficie = 500,
                    ImageUrl = "https://cdn.pixabay.com/photo/2018/03/18/15/26/villa-3237114_960_720.jpg",
                    Rate = 6.2,
                    Created_date = DateTime.Now
                },
                new Villa()
                {
                    Id = 12340,
                    Name = "Villa Monastir",
                    Description = "Description villa Monastir",
                    NbRoom = 3,
                    Superficie = 800,
                    ImageUrl = "https://cdn.pixabay.com/photo/2017/04/10/22/28/residence-2219972_960_720.jpg",
                    Rate = 10,
                    Created_date = DateTime.Now
                }
                );
        }
    }
}
