using Common;
using DataAccess;
using System.Collections.Generic;


namespace Services.EstudianteServices
{
    public interface IEstudianteServices
    {
        List<Estudiante> GetallEstudiantes();

        Estudiante GetEstudianteById(int id);

        OperationResult<Estudiante> SaveEstudiante(Estudiante model);
        OperationResult<Estudiante> UpdateEstudiante(Estudiante model);
        OperationResult<Estudiante> IsActiveEstudiante(Estudiante model);
    }
}
