using Common;
using DataAccess;
using System.Collections.Generic;


namespace Services.EstudianteServices
{
    public interface IEstudianteServices
    {
        IEnumerable<Estudiante> GetallEstudiantes();
        Estudiante GetEstudianteById(int? id);
        Estudiante GetFullEstudianteById(int? id);
        OperationResult<Estudiante> SaveEstudiante(Estudiante model);
        OperationResult<Estudiante> UpdateEstudiante(Estudiante model);
        OperationResult<Estudiante> DisableEstudiante(Estudiante model);
    }
}
