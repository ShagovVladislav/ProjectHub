using Microsoft.AspNetCore.Mvc;
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
}
