using Microsoft.EntityFrameworkCore;
using StudentService.Data;
using StudentService.Models;

namespace StudentService.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly StudentContext _context;

    public StudentRepository(StudentContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _context.Students.ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _context.Students.FindAsync(id);
    }

    public async Task<Student> CreateAsync(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return student;
    }

    public async Task UpdateAsync(Student student)
    {
        _context.Entry(student).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student != null)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}