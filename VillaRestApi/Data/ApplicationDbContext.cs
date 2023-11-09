using Microsoft.EntityFrameworkCore;
using VillaRestApi.Models;

namespace VillaRestApi.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        
        } 
        public DbSet<Villa> Villas { get; set; }
    }
}
