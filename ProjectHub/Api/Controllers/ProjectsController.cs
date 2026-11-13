using Microsoft.AspNetCore.Mvc;
using ProjectHub.Api.DTOs.Requests;
using ProjectHub.Api.DTOs.Responses;
using ProjectHub.Api.Services.Interfaces;

namespace ProjectHub.Api.Controllers;

[ApiController]
[Route("projects/")]
public class ProjectsController(IProjectService projectService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProjectResponse?>> GetProject(Guid id, Guid userId)
    {
        return await projectService.GetProject(id, userId);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<ProjectResponse>>> GetProjects()
    {
        return await projectService.GetAllProjects();
    }
    
    [HttpGet("{userId:guid}/projects")]
    public async Task<ActionResult<List<ProjectResponse>>> GetProjectsByUser(Guid userId)
    {
        return await projectService.GetAllProjectsByUser(userId);
    }
    
    [HttpPost]
    public async Task<ActionResult<ProjectResponse?>> CreateProject(ProjectCreateUpdateRequest updateRequest)
    {
        return await projectService.CreateProject(updateRequest);
    }
    
    [HttpPut]
    public async Task<ActionResult<ProjectResponse?>> UpdateProject(ProjectCreateUpdateRequest updateRequest, Guid userId)
    {
        return await projectService.UpdateProject(updateRequest, userId);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteProject(Guid id, Guid userId)
    {
        await projectService.DeleteProject(id, userId);
        return Ok();
    }
}
