using ProjectHub.Api.Domain;
using ProjectHub.Api.Repositories.Interfaces;
using ProjectHub.Api.Storage;

namespace ProjectHub.Api.Repositories;

public class ProjectRepository : IProjectRepository
{
    public ProjectRepository(AppDbContext context)
    {
        
    }
    
    public Task<List<Project>> GetAllProjects()
    {
        throw new NotImplementedException();
    }

    public Task<Project> GetProject(Guid projectId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Project>> GetAllProjectsByUser(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<Project> GetAllProjectsByTitle(string title)
    {
        throw new NotImplementedException();
    }

    public Task<Project> CreateProject(Project project)
    {
        throw new NotImplementedException();
    }

    public Task<Project> UpdateProject(Project project)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProject(Guid projectId)
    {
        throw new NotImplementedException();
    }
}