using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data;
using SchoolProject.ViewModels;

namespace SchoolProject.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _ctx;

        public DashboardController(ApplicationDbContext context)
        {
            _ctx = context;
        }

        [HttpGet]
        public IActionResult Dashboard(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Students(int? pageNumber)
        {
            int pageSize = 8; // Número de elementos por página
            var students = GetStudentsList();
            var paginatedList = await PaginatedList<StudentViewModel>.CreateAsync(
            students.AsNoTracking(), // Es mejor usar AsNoTracking para consultas de solo lectura
            pageNumber ?? 1,
            pageSize
            );

            return View("Students", paginatedList);
        }

        private IQueryable<StudentViewModel> GetStudentsList()
        {
            return _ctx.Students
                .Where(s => s.IsActive)
                .Select(s => new StudentViewModel
                {
                    StudentId = s.StudentId,
                    Code = s.Code,
                    Name = s.Name,
                    Lastname = s.Lastname,
                    BirthDate = s.BirthDate,
                    Gender = s.Gender,
                    Address = s.Address,
                    Phone = s.Phone,
                    Email = s.Email,
                    GuardianName = s.GuardianName,
                    GuardianPhone = s.GuardianPhone,
                    EnrollmentDate = s.EnrollmentDate,
                    IsActive = s.IsActive
                });
        }


    }
}
