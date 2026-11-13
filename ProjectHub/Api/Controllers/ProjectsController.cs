using Microsoft.AspNetCore.Mvc;
using ProjectHub.Api.DTOs.Requests;
using ProjectHub.Api.DTOs.Responses;
using ProjectHub.Api.Services.Interfaces;

namespace ProjectHub.Api.Controllers;

[ApiController]
[Route("projects/")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;
    
    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProjectResponse>> GetProject(Guid id)
    {
        return await _projectService.GetProject(id);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<ProjectResponse>>> GetProjects()
    {
        return await _projectService.GetAllProjects();
    }
    
    [HttpGet("{userId:guid}/projects")]
    public async Task<ActionResult<List<ProjectResponse>>> GetProjectsByUser(Guid userId)
    {
        return await _projectService.GetAllProjectsByUser(userId);
    }
    
    [HttpPost]
    public async Task<ActionResult<ProjectResponse>> CreateProject(ProjectCreateUpdateRequest updateRequest)
    {
        return await _projectService.CreateProject(updateRequest);
    }
    
    [HttpPut]
    public async Task<ActionResult<ProjectResponse>> UpdateProject(ProjectCreateUpdateRequest updateRequest)
    {
        return await _projectService.UpdateProject(updateRequest);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteProject(Guid id)
    {
        await _projectService.DeleteProject(id);
        return Ok();
    }
}
