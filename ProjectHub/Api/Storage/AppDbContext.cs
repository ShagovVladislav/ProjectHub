using Microsoft.EntityFrameworkCore;
using ProjectHub.Api.Models;

namespace ProjectHub.Api.Storage;

public class AppDbContext : DbContext
{
    public DbSet<ProjectModel> Projects => Set<ProjectModel>();
    public AppDbContext(DbContextOptions options) : base(options) { }
    
    public DbSet<ProjectModel> ProjectModels => Set<ProjectModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
           .Properties<string>()
           .HaveMaxLength(10000);
        
        base.ConfigureConventions(configurationBuilder);
    }
}