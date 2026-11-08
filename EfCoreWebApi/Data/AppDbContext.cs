using Microsoft.EntityFrameworkCore;
using EfCoreWebApi.Data.Entities;

namespace EfCoreWebApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Blogpost> Blogposts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Titel).IsRequired().HasMaxLength(50);
            entity.Property(p => p.Categorie).HasMaxLength(25);
            entity.Property(p => p.Categorie).IsRequired();
            entity.Property(p => p.GitHubUrl).HasMaxLength(2048);
            entity.Property(p => p.GitHubUrl).IsRequired();
            entity.Property(p => p.Beschrijving).HasColumnType("nvarchar(max)"); 
        });

        modelBuilder.Entity<Blogpost>(entity =>
        {
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Titel).IsRequired().HasMaxLength(50);
            entity.Property(b => b.Inhoud).HasColumnType("nvarchar(max)");
        });
    }
}
