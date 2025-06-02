using StudentService.Models;

namespace StudentService.Repositories;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAllAsync();
    Task<Student?> GetByIdAsync(int id);
    Task<Student> CreateAsync(Student student);
    Task UpdateAsync(Student student);
    Task DeleteAsync(int id);
}