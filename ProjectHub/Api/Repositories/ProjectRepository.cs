using ProjectHub.Api.Domain;
using ProjectHub.Api.Repositories.Interfaces;

namespace ProjectHub.Api.Repositories;

public class ProjectRepository : IProjectRepository
{
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

    public Task<Project> CreateProject(Project request)
    {
        throw new NotImplementedException();
    }

    public Task<Project> ChangeProject(Guid projectId, string title, string description)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProject(Guid projectId)
    {
        throw new NotImplementedException();
    }
}