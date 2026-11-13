using Microsoft.EntityFrameworkCore;
using ProjectHub.Api.Domain;
using ProjectHub.Api.Mappers.EntityModelMapper;
using ProjectHub.Api.Repositories.Interfaces;
using ProjectHub.Api.Storage;

namespace ProjectHub.Api.Repositories;

public class ProjectRepository(AppDbContext context) : IProjectRepository
{
    public async Task<List<Project>> GetAllProjects()
    {
        var projects = await context.Projects
           .AsNoTracking()
           .Where(x => !x.IsPrivate)
           .Select(x => x.ToEntity())
           .ToListAsync();
        
        return projects;
    }

    public async Task<Project?> GetProject(Guid projectId, Guid userId)
    {
        var project = await context.Projects
                         .AsNoTracking()
                         .FirstOrDefaultAsync(x => 
                    x.Id == projectId && 
                    x.AuthorId == userId || 
                    x.Collaborators.Contains(userId) || 
                    !x.IsPrivate) 
                      ?? throw new NullReferenceException();

        return project.ToEntity();   
    }

    public async Task<List<Project>> GetAllProjectsByUser(Guid userId)
    {
        var projects = await context.Projects
           .AsNoTracking()
           .Where(x => x.AuthorId == userId)
           .Select(x => x.ToEntity())
           .ToListAsync();
        
        return projects;    
    }

    public async Task<List<Project>> GetAllProjectsByTitle(string title = "", int limit = 10)
    {
        title = title.Trim();
        
        var projects = await context.Projects
           .AsNoTracking()
           .Where(x => !x.IsPrivate)
           .Where(x => EF.Functions.ILike(x.Title, $"%{title}%"))
           .OrderByDescending(x => EF.Functions.TrigramsSimilarity(x.Title, title))
           .ThenBy(x => x.Title)
           .Take(limit)
           .Select(x => x.ToEntity())
           .ToListAsync();
        
        return projects;        
    }
    
    public async Task<List<Project>> GetAllMyProjectsByTitle(Guid userId , int limit = 10)
    {
        var projects = await context.Projects
           .AsNoTracking()
           .Where(x => x.AuthorId == userId || x.Collaborators.Contains(userId))
           .OrderByDescending(x => x.UpdatedAt)
           .Take(limit)
           .Select(x => x.ToEntity())
           .ToListAsync();
        
        return projects;        
    }

    public async Task<Project?> CreateProject(Project project)
    {
        project.UpdatedAt = DateTimeOffset.UtcNow;
        await context.Projects.AddAsync(project.ToModel());
        await context.SaveChangesAsync();
        
        return project;
    }

    public async Task<Project?> UpdateProject(Project project, Guid userId)
    {
        if (project.AuthorId != userId)
            return null;
        
        var projectToUpdate = await context.Projects.FirstOrDefaultAsync(x => x.Id == project.Id)
            ?? throw new NullReferenceException();
        context.Entry(projectToUpdate).CurrentValues.SetValues(project.ToModel());
        projectToUpdate.UpdatedAt = DateTimeOffset.UtcNow;
        await context.SaveChangesAsync();
        
        return projectToUpdate.ToEntity();
    }

    public async Task DeleteProject(Guid projectId, Guid userId)
    {
        if (projectId != userId)
            return;
        
        var projectToDelete = await context.Projects.FirstOrDefaultAsync(x => x.Id == projectId)
                              ?? throw new NullReferenceException();
        context.Projects.Remove(projectToDelete);
        await context.SaveChangesAsync();
    }
}