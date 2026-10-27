using System.ComponentModel.DataAnnotations;

namespace ProjectHub.Api.Models;

public class ProjectModel
{
    public Guid Id { get; set; }
    [MaxLength(255)]
    public string Title { get; set; } = string.Empty;
    [MaxLength(10000)]
    public string Description { get; set; } = string.Empty;
    public Guid AuthorID { get; set; }
    public List<Guid> Collaborators { get; set; } = [];
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}