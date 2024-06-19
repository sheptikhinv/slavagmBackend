using Microsoft.EntityFrameworkCore;
using slavagmBackend.Entities;

namespace slavagmBackend;

public class DataContext : DbContext
{
    public DbSet<Card> Cards { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<SkillChild> ChildSkills { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}