using ProjectHub.Api.DTOs.Requests;
using ProjectHub.Api.DTOs.Responses;
using ProjectHub.Api.Mappers.DtoEntityMappers;
using ProjectHub.Api.Repositories.Interfaces;
using ProjectHub.Api.Services.Interfaces;

namespace ProjectHub.Api.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    
    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    
    public Task<List<ProjectResponse>> GetAllProjects()
    {
        throw new NotImplementedException();
    }

    public async Task<ProjectResponse> GetProject(Guid projectId)
    {
        return (await _projectRepository.GetProject(projectId)).ToDto();
    }

    public Task<List<ProjectResponse>> GetAllProjectsByUser(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<ProjectResponse> GetAllProjectsByTitle(string title)
    {
        throw new NotImplementedException();
    }

    public Task<ProjectResponse> CreateProject(ProjectCreateRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ProjectResponse> ChangeProject(Guid projectId, string title, string description)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProject(Guid projectId)
    {
        throw new NotImplementedException();
    }
}