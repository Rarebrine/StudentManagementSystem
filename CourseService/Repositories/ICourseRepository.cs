using CourseService.Models;

namespace CourseService.Repositories;

public interface ICourseRepository
{
    Task<IEnumerable<Course>> GetAllAsync();
    Task<Course?> GetByIdAsync(int id);
    Task<Course> AddAsync(Course course);
    Task<bool> UpdateAsync(Course course);
    Task<bool> DeleteAsync(int id);
}
