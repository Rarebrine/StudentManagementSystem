using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentService.Models;
using StudentService.Repositories;

namespace StudentService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentRepository _repo;

    public StudentsController(IStudentRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var students = await _repo.GetAllAsync();
        return Ok(students);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var student = await _repo.GetByIdAsync(id);
        if (student == null) return NotFound();
        return Ok(student);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Student student)
    {
        var created = await _repo.CreateAsync(student);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Student student)
    {
        if (id != student.Id) return BadRequest();
        await _repo.UpdateAsync(student);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repo.DeleteAsync(id);
        return NoContent();
    }
}