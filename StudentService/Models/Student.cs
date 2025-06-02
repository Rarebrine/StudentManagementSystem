using System.ComponentModel.DataAnnotations;

namespace StudentService.Models;

public class Student
{
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    [EmailAddress]
    public string? Email { get; set; }

    public DateOnly DateOfBirth { get; set; }
}