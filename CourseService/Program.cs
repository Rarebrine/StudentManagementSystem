using CourseService.Data;
using CourseService.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure MySQL
var connStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CourseContext>(opts =>
    opts.UseMySql(connStr, ServerVersion.AutoDetect(connStr)));

// Register repository
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

// Add controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
