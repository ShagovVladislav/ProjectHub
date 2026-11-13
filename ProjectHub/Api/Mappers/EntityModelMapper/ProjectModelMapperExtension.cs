using ProjectHub.Api.Domain;
using ProjectHub.Api.Models;

namespace ProjectHub.Api.Mappers.EntityModelMapper;

public static class ProjectModelMapperExtension
{
    public static ProjectModel ToModel(this Project project)
    {
        return new ProjectModel
        {
            Id = project.Id,
            Title = project.Title,
            Description = project.Description,
            CreatedAt = project.CreatedAt,
            IsPrivate =  project.IsPrivate,
            AuthorId = project.AuthorId,
            UpdatedAt = project.UpdatedAt
        };
    }

    public static Project ToEntity(this ProjectModel model)
    {
        return new Project
        {
            Id = model.Id,
            Title = model.Title,
            Description = model.Description,
            AuthorId = model.AuthorId,
            Collaborators =  model.Collaborators,
            IsPrivate = model.IsPrivate,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt
        };
    }
}