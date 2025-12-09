using System.ComponentModel.DataAnnotations;

namespace CollabTask.Application;

public record CreateProjectDto
{
    [Required(ErrorMessage = "Tên dự án là bắt buộc")]
    [MaxLength(100, ErrorMessage = "Tên dự án không được quá 100 ký tự")]
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}