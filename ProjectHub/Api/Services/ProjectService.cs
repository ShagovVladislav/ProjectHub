using ProjectHub.Api.Domain;
using ProjectHub.Api.DTOs.Requests;
using ProjectHub.Api.DTOs.Responses;
using ProjectHub.Api.Mappers.DtoEntityMappers;
using ProjectHub.Api.Repositories.Interfaces;
using ProjectHub.Api.Services.Interfaces;

namespace ProjectHub.Api.Services;

public class ProjectService(IProjectRepository projectRepository) : IProjectService
{
    public async Task<List<ProjectResponse>> GetAllProjects()
    {
        return (await projectRepository.GetAllProjects()).Select(x => x.ToDto()).ToList();
    }

    public async Task<ProjectResponse?> GetProject(Guid projectId, Guid userId)
    {
        return (await projectRepository.GetProject(projectId, userId))?.ToDto();
    }

    public async Task<List<ProjectResponse>> GetAllProjectsByUser(Guid userId)
    {
        return (await projectRepository.GetAllProjectsByUser(userId)).Select(x => x.ToDto()).ToList();
    }

    public async Task<ProjectResponse?> CreateProject(ProjectCreateUpdateRequest createRequest)
    {
        var project = new Project
        {
            Id = Guid.NewGuid(),
            Title = createRequest.Title,
            Description = createRequest.Description,
            AuthorId = Guid.NewGuid(),//todo юзеры
            CreatedAt =  DateTimeOffset.UtcNow,
            UpdatedAt =  DateTimeOffset.UtcNow,
            Collaborators = []
        };
        
        return (await projectRepository.CreateProject(project))?.ToDto();
    }

    public async Task<ProjectResponse?> UpdateProject(ProjectCreateUpdateRequest updateRequest,  Guid userId)
    {
        var project = await projectRepository.GetProject(updateRequest.ProjectId,  userId);
        if (project == null)
            throw new Exception("Project not found");
        project.Title = updateRequest.Title;
        project.Description = updateRequest.Description;
        project.UpdatedAt = DateTimeOffset.UtcNow;

        return (await projectRepository.UpdateProject(project, userId))?.ToDto();
    }

    public async Task DeleteProject(Guid projectId, Guid userId)
    {
        await projectRepository.DeleteProject(projectId, userId);    
    }
}