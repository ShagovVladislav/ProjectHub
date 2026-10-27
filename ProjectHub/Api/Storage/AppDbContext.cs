using Microsoft.EntityFrameworkCore;
using ProjectHub.Api.Models;

namespace ProjectHub.Api.Storage;

public class AppDbContext : DbContext
{
    public DbSet<ProjectModel> Projects => Set<ProjectModel>();
    public AppDbContext(DbContextOptions options) : base(options) { }
    
}