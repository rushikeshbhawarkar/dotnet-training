using aug_04.Data;
using aug_04.Model;
using aug_04.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace aug_04.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student? GetStudent(int id)
        {
            return _context.Students.Find(id);
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }
    }
}





//public class StudentService : IStudentService { private readonly AppDbContext context; public StudentService(AppDbContext context) { this.context = context; } public void AddStudent(Student student) { context.Students.Add(student); context.SaveChanges(); } public void DeleteStudent(int id) { var student = context.Students.Find(id); if (student != null) { context.Students.Remove(student); context.SaveChanges(); } } public List<Student> GetAll() { return context.Students.ToList(); } public Student? GetStudent(int id) { return context.Students.Find(id); } public void UpdateStudent(Student student) { context.Students.Update(student); context.SaveChanges(); } }
//public class AppDbContext : DbContext { public AppDbContext(DbContextOptions options) : base(options) { } public DbSet<Student> Students { get; set; } }
//public class StudentsController : ControllerBase { private readonly IStudentService service; public StudentsController(IStudentService service) { this.service = service; } [HttpGet] public IActionResult Get() { return Ok(service.GetAll()); } [HttpGet("{id}")] public IActionResult GetId(int id) { var student = service.GetStudent(id); if (student == null) return NotFound("Student not found"); return Ok(student); } [HttpPost] public IActionResult AddS(Student student) { service.AddStudent(student); return Ok(student); } [HttpPut("{id}")] public IActionResult UpdateS(int id, Student student) { if (id != student.Id) return BadRequest(); var exisitng = service.GetStudent(id); if (exisitng == null) return NotFound(); service.UpdateStudent(student); return Ok(student); } [HttpDelete] public IActionResult Delete(int id) { var student = service.GetStudent(id); if (student == null) return NotFound(); service.DeleteStudent(id); return Ok("Student Deleted Successfully"); } }
////Di builder.Services.AddScoped<IStudentService, StudentService>(); //Swagger builder.Services.AddEndpointsApiExplorer(); builder.Services.AddSwaggerGen(); //database builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer( builder.Configuration.GetConnectionString("DefaultConnection"))); var app = builder.Build(); app.UseSwagger(); app.UseSwaggerUI();
//{ "ConnectionStrings": { "DefaultConnection": "Server=(localDB)\\MSSQLLocalDB;Database=StudentDb;Trusted_Connection=True;" } }
//Add - Migration InitialCreate
//Update-Database