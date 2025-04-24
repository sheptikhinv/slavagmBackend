using Microsoft.EntityFrameworkCore;
using slavagmBackend.Core.Models;

namespace slavagmBackend.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Card> Cards { get; set; }
    public DbSet<Skill> Skills { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}