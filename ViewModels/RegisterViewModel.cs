using System.ComponentModel.DataAnnotations;

namespace SchoolProject.ViewModels
{
    public class RegisterViewModel
    {
        
        [Display(Name = "Usuario")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre de usuario debe tener entre 3 y 50 caracteres")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "El nombre de usuario solo puede contener letras, números y guiones bajos")]
        public string UserName { get; set; }               

        
        [EmailAddress(ErrorMessage = "El formato del email no es válido")]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        public string Password { get; set; }

        
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmPassword { get; set; }


        // ===== DATOS DE PROFESOR (OPCIONAL AL REGISTRARSE) =====

        [Display(Name = "¿Desea crear su perfil de profesor ahora?")]
        public bool CreateProfessorProfile { get; set; } = true;

        
        [StringLength(20, ErrorMessage = "El código no puede exceder 20 caracteres")]
        [Display(Name = "Código de Profesor")]
        public string ProfessorCode { get; set; }

        
        [StringLength(50, ErrorMessage = "El nombre no puede exceder 50 caracteres")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        
        [StringLength(50, ErrorMessage = "El apellido no puede exceder 50 caracteres")]
        [Display(Name = "Lastname")]
        public string Lastname { get; set; }

        [Phone(ErrorMessage = "El formato del teléfono no es válido")]
        [StringLength(20, ErrorMessage = "El teléfono no puede exceder 20 caracteres")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        
        [StringLength(100, ErrorMessage = "La especialidad no puede exceder 100 caracteres")]
        [Display(Name = "Department")]
        public string Department { get; set; }

        // Propiedad calculada para mostrar el nombre completo
        public string FullName => $"{Name} {Lastname}";



    }
}
