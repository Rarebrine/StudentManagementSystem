using Microsoft.EntityFrameworkCore;
using StudentService.Models;

namespace StudentService.Data;

public class StudentContext : DbContext
{
    public StudentContext(DbContextOptions<StudentContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students => Set<Student>();
}