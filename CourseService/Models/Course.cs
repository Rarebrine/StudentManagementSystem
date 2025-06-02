using System.ComponentModel.DataAnnotations;

namespace CourseService.Models;

public class Course
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = null!;

    [MaxLength(250)]
    public string? Description { get; set; }

    [Range(1, 10)]
    public int Credits { get; set; }
}
