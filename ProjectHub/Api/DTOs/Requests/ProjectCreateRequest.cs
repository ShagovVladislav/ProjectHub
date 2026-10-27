namespace ProjectHub.Api.DTOs.Requests;

public class ProjectCreateRequest
{
    public Guid ProjectId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid AuthorID { get; set; }
}