using System;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModel
{
    public class UsuarioViewModel
    {
        public int Id_usuario { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es oblogatorio")]
        [Display(Name = "Nombre de usuario")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "La contraseña es obligaroria")]
        [Display(Name = "Contraseña")]
        public string Clave { get; set; }

        [Required(ErrorMessage = "La contraseña es obligaroria")]
        [Display(Name = "Confimar contraseña")]
        [Compare("Clave", ErrorMessage = "Las contraseñas no son iguales")]
        public string ConfirmarClave { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool? IsActive { get; set; }
    }
}