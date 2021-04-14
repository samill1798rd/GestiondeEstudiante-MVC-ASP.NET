using Common;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EstudianteServices
{
    public interface IEstudianteServices
    {
        List<Estudiante> GetallEstudiantes();

        Estudiante GetEstudianteById(int id);

        OperationResult<Estudiante> SaveEstudiante(Estudiante model);
    }
}
