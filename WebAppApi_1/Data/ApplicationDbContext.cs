using Microsoft.EntityFrameworkCore;
using WebAppApi_1.Models;

namespace WebAppApi_1.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<ItemModel> Items { get; set; }
    }
}
