using ProjectHub.Api.Domain;
using ProjectHub.Api.DTOs.Responses;

namespace ProjectHub.Api.Mappers.DtoEntityMappers;

public static class ProjectDtoMapperExtension
{
    public static ProjectResponse ToDto(this Project project)
    {
        return new ProjectResponse
        {
            Id = project.Id,
            Title = project.Title,
            Description = project.Description
        };
    }

    public static Project ToEntity(this ProjectResponse model)
    {
        return new Project
        {
            Id = model.Id,
            Title = model.Title,
            Description = model.Description,
            UpdatedAt = DateTimeOffset.UtcNow
        };
    }
}