using DataAccess;
using System;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModel
{
    public class EstudianteViewModel
    {
        public int Id_Estudiantes { get; set; }
        [MaxLength(40, ErrorMessage ="*Maximo 40 caracteres ")]
        [Required(ErrorMessage = "*Este campo es requerido")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [MaxLength(40, ErrorMessage = "*Maximo 40 caracteres ")]
        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "*Este campo es requerido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "*Este campo es requerido")]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime? FechaNacimiento { get; set; }

        public byte[] Imagen { get; set; }

        [Required(ErrorMessage = "*Este campo es requerido")]
        public int? Matricula { get; set; }

        [Required(ErrorMessage = "*Este campo es requerido")]
        public int? Nacionalidad_id { get; set; }

        [Required(ErrorMessage = "*Este campo es requerido")]
        public int? Carrera { get; set; }

        [Display(Name = "Inicio de carrera")]
        [Required(ErrorMessage = "*Este campo es requerido")]
        public DateTime? FechaInicio { get; set; }

        [Display(Name = "Finalizacion de carrera")]
        [Required(ErrorMessage = "*Este campo es requerido")]
        public DateTime? FechaFinalizacion { get; set; }

        public bool? IsActive { get; set; }

        [Display(Name = "Nacionalidad")]
        public nacionalidad nacionalidad { get; set; }
    }
}