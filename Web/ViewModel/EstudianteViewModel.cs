using DataAccess;
using System;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModel
{
    public class EstudianteViewModel
    {
        public int Id_Estudiantes { get; set; }
        [Display(Name = "Nombre Test")]
        public string Nombre { get; set; }    
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public byte[] Imagen { get; set; }
        public int? Matricula { get; set; }
        public int? Nacionalidad_id { get; set; }
        public int? Carrera { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public bool? IsActive { get; set; }

        public nacionalidad nacionalidad { get; set; }
    }
}