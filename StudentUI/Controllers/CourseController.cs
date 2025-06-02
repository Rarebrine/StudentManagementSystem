using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using StudentUI.Models;

namespace StudentUI.Controllers
{
    public class CourseController : Controller
    {
        private readonly HttpClient _http;

        public CourseController(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("CourseService");
        }

        public async Task<IActionResult> Index()
        {
            var list = await _http.GetFromJsonAsync<List<CourseDto>>("api/courses");
            return View("~/Views/Courses/Index.cshtml", list); // ✅ fixed path
        }

        public IActionResult Create()
            => View("~/Views/Courses/Create.cshtml"); // ✅

        [HttpPost]
        public async Task<IActionResult> Create(CourseDto c)
        {
            await _http.PostAsJsonAsync("api/courses", c);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var c = await _http.GetFromJsonAsync<CourseDto>($"api/courses/{id}");
            if (c is null) return NotFound();
            return View("~/Views/Courses/Edit.cshtml", c); // ✅
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CourseDto c)
        {
            await _http.PutAsJsonAsync($"api/courses/{c.Id}", c);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var c = await _http.GetFromJsonAsync<CourseDto>($"api/courses/{id}");
            if (c is null) return NotFound();
            return View("~/Views/Courses/Details.cshtml", c); // ✅
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _http.DeleteAsync($"api/courses/{id}");

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Failed to delete course.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
