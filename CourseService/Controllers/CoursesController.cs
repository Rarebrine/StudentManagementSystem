using CourseService.Models;
using CourseService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CourseService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly ICourseRepository _repo;

    public CoursesController(ICourseRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Course>>> GetAll()
    {
        return Ok(await _repo.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Course>> Get(int id)
    {
        var course = await _repo.GetByIdAsync(id);
        if (course == null) return NotFound();
        return Ok(course);
    }

    [HttpPost]
    public async Task<ActionResult<Course>> Create(Course course)
    {
        var created = await _repo.AddAsync(course);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Course course)
    {
        if (id != course.Id) return BadRequest();
        var updated = await _repo.UpdateAsync(course);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _repo.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
