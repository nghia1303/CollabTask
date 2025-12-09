using System.ComponentModel.DataAnnotations;

namespace CollabTask.Application.Dtos;

public record ProjectDto(Guid id, string Name, string? Description, DateTime CreatedDate);

