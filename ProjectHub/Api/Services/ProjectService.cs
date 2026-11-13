using ProjectHub.Api.Domain;
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
    
    public async Task<List<ProjectResponse>> GetAllProjects()
    {
        return (await _projectRepository.GetAllProjects()).Select(x => x.ToDto()).ToList();
    }

    public async Task<ProjectResponse> GetProject(Guid projectId)
    {
        return (await _projectRepository.GetProject(projectId)).ToDto();
    }

    public async Task<List<ProjectResponse>> GetAllProjectsByUser(Guid userId)
    {
        return (await _projectRepository.GetAllProjectsByUser(userId)).Select(x => x.ToDto()).ToList();
    }

    public async Task<ProjectResponse> CreateProject(ProjectCreateUpdateRequest createRequest)
    {
        var project = new Project
        {
            Id = Guid.NewGuid(),
            Title = createRequest.Title,
            Description = createRequest.Description,
            AuthorID = Guid.NewGuid(),//todo юзеры
            CreatedAt =  DateTimeOffset.UtcNow,
            UpdatedAt =  DateTimeOffset.UtcNow,
            Collaborators = []
        };
        
        return (await _projectRepository.CreateProject(project)).ToDto();
    }

    public async Task<ProjectResponse> UpdateProject(ProjectCreateUpdateRequest updateRequest)
    {
        var project = await _projectRepository.GetProject(updateRequest.ProjectId);
        project.Title = updateRequest.Title;
        project.Description = updateRequest.Description;
        project.UpdatedAt = DateTimeOffset.UtcNow;

        return (await _projectRepository.UpdateProject(project)).ToDto();
    }

    public async Task DeleteProject(Guid projectId)
    {
        await _projectRepository.DeleteProject(projectId);    
    }
}