using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using StudentUI.Models;

namespace StudentUI.Controllers
{
    public class StudentController : Controller
    {
        private readonly HttpClient _http;

        public StudentController(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("StudentService");
        }

        // List view
        public async Task<IActionResult> Index()
        {
            try
            {
                var students = await _http.GetFromJsonAsync<List<StudentDto>>("api/students");
                return View("~/Views/Students/Index.cshtml", students);
            }
            catch (Exception ex)
            {
                return Content("❌ Error fetching students: " + ex.Message);
            }
        }

        // Show empty form
        public IActionResult Create()
            => View("~/Views/Students/Create.cshtml");

        // Handle form POST
        [HttpPost]
        public async Task<IActionResult> Create(StudentDto s)
        {
            await _http.PostAsJsonAsync("api/students", s);
            return RedirectToAction(nameof(Index));
        }

        // Show edit form
        public async Task<IActionResult> Edit(int id)
        {
            var s = await _http.GetFromJsonAsync<StudentDto>($"api/students/{id}");
            if (s is null) return NotFound();
            return View("/Views/Students/Edit.cshtml", s);  
        }

        // Handle edit POST
        [HttpPost]
        public async Task<IActionResult> Edit(StudentDto s)
        {
            await _http.PutAsJsonAsync($"api/students/{s.Id}", s);
            return RedirectToAction(nameof(Index));
        }

        // Details page
        public async Task<IActionResult> Details(int id)
        {
            var s = await _http.GetFromJsonAsync<StudentDto>($"api/students/{id}");
            if (s is null) return NotFound();
            return View("/Views/Students/Details.cshtml", s);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _http.DeleteAsync($"api/students/{id}");

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Failed to delete student.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
