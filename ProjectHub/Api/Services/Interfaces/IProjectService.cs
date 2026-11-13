using ProjectHub.Api.DTOs.Requests;
using ProjectHub.Api.DTOs.Responses;

namespace ProjectHub.Api.Services.Interfaces;

public interface IProjectService
{
    Task<List<ProjectResponse>> GetAllProjects();
    Task<ProjectResponse> GetProject(Guid projectId);
    Task<List<ProjectResponse>> GetAllProjectsByUser(Guid userId);
    Task <ProjectResponse> CreateProject(ProjectCreateUpdateRequest createRequest);
    Task <ProjectResponse> UpdateProject(ProjectCreateUpdateRequest updateRequest);
    Task DeleteProject(Guid projectId);
}