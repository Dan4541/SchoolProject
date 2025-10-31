using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "El Nombre de Usuario es Obligatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El Nombre de Usuario debe tener entre 3 y 50 caracteres")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "El Nombre Completo es Obligatorio.")]
        [StringLength(100, ErrorMessage = "El Nombre Completo no debe exceder los 100 caracteres.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "El Correo Electrónico es Obligatorio.")]
        [EmailAddress(ErrorMessage = "El Correo Electrónico no es válido.")]
        [StringLength(100, ErrorMessage = "El Correo Electrónico no debe exceder los 100 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La Contraseña es Obligatoria.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La Contraseña debe tener entre 6 y 100 caracteres.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "El Rol es Obligatorio.")]
        [StringLength(20, ErrorMessage = "El Rol no debe exceder los 20 caracteres.")]
        public string Role { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastAccess { get; set; }

        // Navigation property to Professor
        public virtual Professor? Professor { get; set; }
    }
}
