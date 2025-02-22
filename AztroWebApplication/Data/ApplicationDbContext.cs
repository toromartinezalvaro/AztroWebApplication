using Microsoft.EntityFrameworkCore;
using AztroWebApplication.Models;

namespace AztroWebApplication.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> User { get; set; }
  }
}