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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemModel>().HasData(
                  new ItemModel()
                  {
                      Id = 1,
                      Name = "Pankaj",
                      Description = "hey this is automatic.",
                      CreatedDate= DateTime.Now

                  },
                  new ItemModel()
                  {
                      Id = 2,
                      Name = "Sharma",
                      Description = "hey this is automatic22.",
                      CreatedDate = DateTime.Now

                  }, 
                  new ItemModel()
                  {
                      Id = 3,
                      Name = "Hey",
                      Description = "hey this is automatic333.",
                      CreatedDate = DateTime.Now

                  },
                  new ItemModel()
                  {
                      Id = 4,
                      Name = "This",
                      Description = "hey this is automatic4444.",
                      CreatedDate = DateTime.Now

                  },
                  new ItemModel()
                  {
                      Id = 5,
                      Name = "Database",
                      Description = "hey this is automatic55555.",
                      CreatedDate = DateTime.Now

                  }
                );   
        }
    }
}
