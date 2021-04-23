using DataAccess;
using System;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModel
{
    public class EstudianteViewModel
    {
        public int Id_Estudiantes { get; set; }
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }    
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        [Display(Name = "Fecha de nacimiento")]
        public DateTime? FechaNacimiento { get; set; }
        public byte[] Imagen { get; set; }
        public int? Matricula { get; set; }
        public int? Nacionalidad_id { get; set; }
        public int? Carrera { get; set; }
        [Display(Name = "Inicio de carrera")]
        public DateTime? FechaInicio { get; set; }
        [Display(Name = "Finalizacion de carrera")]
        public DateTime? FechaFinalizacion { get; set; }
        public bool? IsActive { get; set; }
        public nacionalidad nacionalidad { get; set; }
    }
}