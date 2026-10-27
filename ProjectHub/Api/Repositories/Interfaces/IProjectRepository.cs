using ProjectHub.Api.Domain;

namespace ProjectHub.Api.Repositories.Interfaces;

public interface IProjectRepository
{
    Task<List<Project>> GetAllProjects();
    Task<Project> GetProject(Guid projectId);
    Task<List<Project>> GetAllProjectsByUser(Guid userId);
    Task<Project> GetAllProjectsByTitle(string title);
    Task <Project> CreateProject(Project request);
    Task <Project> ChangeProject(Guid projectId, string title, string description);
    Task DeleteProject(Guid projectId);
}