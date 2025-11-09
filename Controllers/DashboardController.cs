using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data;
using SchoolProject.Models;
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


        public IActionResult Dashboard(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        public IActionResult Students()
        {
            var students = _ctx.Students
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
                })
                .ToList();

            return View(students);
        }

        [HttpPost]
        public async Task<IActionResult> SaveStudent(StudentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                if (model.StudentId == 0)
                {
                    // Crear nuevo estudiante
                    var student = new Student
                    {
                        Code = model.Code,
                        Name = model.Name,
                        Lastname = model.Lastname,
                        BirthDate = model.BirthDate,
                        Gender = model.Gender,
                        Address = model.Address,
                        Phone = model.Phone,
                        Email = model.Email,
                        GuardianName = model.GuardianName,
                        GuardianPhone = model.GuardianPhone,
                        EnrollmentDate = model.EnrollmentDate,
                        IsActive = model.IsActive
                    };
                    _ctx.Students.Add(student);
                }
                else
                {
                    // Actualizar estudiante existente
                    var student = await _ctx.Students.FindAsync(model.StudentId);
                    if (student != null)
                    {
                        student.Code = model.Code;
                        student.Name = model.Name;
                        student.Lastname = model.Lastname;
                        student.BirthDate = model.BirthDate;
                        student.Gender = model.Gender;
                        student.Address = model.Address;
                        student.Phone = model.Phone;
                        student.Email = model.Email;
                        student.GuardianName = model.GuardianName;
                        student.GuardianPhone = model.GuardianPhone;
                        student.EnrollmentDate = model.EnrollmentDate;
                        student.IsActive = model.IsActive;
                    }
                }

                await _ctx.SaveChangesAsync();
                return RedirectToAction("Students");
            }

            // Si hay errores de validación, regresar a la vista
            var students = await GetStudentsList();
            return View("Students", students);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _ctx.Students.FindAsync(id);
            if (student != null)
            {
                // Eliminación suave (cambiar estado a inactivo)
                student.IsActive = false;
                await _ctx.SaveChangesAsync();
            }

            return RedirectToAction("Students");
        }

        private async Task<System.Collections.Generic.List<StudentViewModel>> GetStudentsList()
        {
            return await _ctx.Students
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
                })
                .ToListAsync();
        }

    }
}
