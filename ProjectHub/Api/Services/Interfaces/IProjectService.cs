using ProjectHub.Api.DTOs.Requests;
using ProjectHub.Api.DTOs.Responses;

namespace ProjectHub.Api.Services.Interfaces;

public interface IProjectService
{
    Task<List<ProjectResponse>> GetAllProjects();
    Task<ProjectResponse> GetProject(Guid projectId);
    Task<List<ProjectResponse>> GetAllProjectsByUser(Guid userId);
    Task<ProjectResponse> GetAllProjectsByTitle(string title);
    Task <ProjectResponse> CreateProject(ProjectCreateRequest request);
    Task <ProjectResponse> ChangeProject(Guid projectId, string title, string description);
    Task DeleteProject(Guid projectId);
}