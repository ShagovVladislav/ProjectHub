using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectHub.Api.Models;

namespace ProjectHub.Api.Storage.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<ProjectModel>
{
    public void Configure(EntityTypeBuilder<ProjectModel> builder)
    {
        builder.ToTable("Projects");
        
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
           .HasColumnName("id")
           .HasColumnType("uuid")
           .HasDefaultValueSql("gen_random_uuid()")
           .ValueGeneratedOnAdd();

        builder.Property(p => p.Title)
           .HasColumnName("title")
           .HasMaxLength(200)
           .IsRequired();
        
        builder.Property(p => p.Description)
           .HasColumnName("description")
           .HasMaxLength(10000);
        
        builder.Property(p => p.AuthorId)
          .HasColumnName("author_id")
          .IsRequired();
        
        builder.Property(p => p.Collaborators)
           .HasColumnName("collaborators")
           .HasMaxLength(10000);
        
        builder.Property(p => p.CreatedAt)
           .HasColumnName("created_at")
           .HasColumnType("datetime")
           .IsRequired();
        
        builder.Property(p => p.UpdatedAt)
           .HasColumnName("updated_at")
           .HasColumnType("datetime");
    }
}