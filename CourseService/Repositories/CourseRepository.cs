using CourseService.Data;
using CourseService.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseService.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly CourseContext _context;

    public CourseRepository(CourseContext context)
    {
        _context = context;
    }

    public async Task<Course> AddAsync(Course course)
    {
        _context.Courses.Add(course);
        await _context.SaveChangesAsync();
        return course;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course == null) return false;
        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Course>> GetAllAsync()
        => await _context.Courses.AsNoTracking().ToListAsync();

    public async Task<Course?> GetByIdAsync(int id)
        => await _context.Courses.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

    public async Task<bool> UpdateAsync(Course course)
    {
        if (!await _context.Courses.AnyAsync(c => c.Id == course.Id))
            return false;

        _context.Courses.Update(course);
        await _context.SaveChangesAsync();
        return true;
    }
}
