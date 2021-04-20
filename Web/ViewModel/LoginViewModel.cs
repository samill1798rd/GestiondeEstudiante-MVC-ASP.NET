using System.ComponentModel.DataAnnotations;

namespace Web.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="El nombre de usuario es oblogatorio")]
        [Display(Name = "Nombre de usuario")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "La contraseña es obligaroria")]
        [Display(Name = "Contraseña")]
        public string Clave { get; set; }
    }
}