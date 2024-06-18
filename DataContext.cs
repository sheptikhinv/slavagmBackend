using Microsoft.EntityFrameworkCore;
using slavagmBackend.Entities;

namespace slavagmBackend;

public class DataContext : DbContext
{
    public DbSet<Card?> Cards { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}