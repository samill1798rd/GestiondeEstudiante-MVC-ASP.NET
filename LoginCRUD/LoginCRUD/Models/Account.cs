using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginCRUD.Models
{
    public class Account
    {
        public int Id_usuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string FechaCreacion { get; set; }
        public bool IsActive { get; set; } 
    }
}