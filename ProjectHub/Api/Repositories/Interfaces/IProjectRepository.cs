using ProjectHub.Api.Domain;

namespace ProjectHub.Api.Repositories.Interfaces;

public interface IProjectRepository
{
    Task<List<Project>> GetAllProjects();
    Task<Project?> GetProject(Guid projectId, Guid userId);
    Task<List<Project>> GetAllProjectsByUser(Guid userId);
    Task<List<Project>> GetAllProjectsByTitle(string title, int limit);
    Task <Project?> CreateProject(Project project);
    Task<Project?> UpdateProject(Project project, Guid userId);
    Task DeleteProject(Guid projectId, Guid userId);
}