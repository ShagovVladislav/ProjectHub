namespace ProjectHub.Api.Domain;

public class Project
{
    public Project()
    {
    }
    
    public Project(Guid projectId, string title, string description, Guid authorId, List<Guid> collaborators,
        DateTimeOffset createdAt, DateTimeOffset updatedAt)
    {
        Id = projectId;
        Title = title;
        Description = description;
        AuthorId = authorId;
        Collaborators = collaborators;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
    
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid AuthorId { get; set; }
    public List<Guid> Collaborators { get; set; } = [];
    public bool IsPrivate { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}