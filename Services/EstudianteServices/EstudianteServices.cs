using Common;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Services.EstudianteServices
{
    public class EstudianteServices : IEstudianteServices
    {
        private GestionDB _GestionDB;
        public EstudianteServices()
        {
            _GestionDB = new GestionDB();
        }

        public IEnumerable<Estudiante> GetallEstudiantes()
        {
            var ListEstudiante = _GestionDB.Estudiantes
                                          .Include("nacionalidad")
                                          .OrderBy(x => x.Nombre)
                                          .Where(x => x.IsActive == true)
                                          .AsQueryable();

            return ListEstudiante;
        }

        public Estudiante GetEstudianteById(int id)
        {
            var estudiante = _GestionDB.Estudiantes.Find(id);

            return estudiante;
        }

        public OperationResult<Estudiante> SaveEstudiante(Estudiante model)
        {
            var Operation = new OperationResult<Estudiante>();

            try
            {
                var estudiante = _GestionDB.Estudiantes.Add(model);
                _GestionDB.SaveChanges();
                Operation.Mensaje.Add("Todo Bien");
                Operation.ResultObject = model;
                Operation.Ok = true;
            }
            catch (Exception)
            {
                Operation.Mensaje.Add("Algo salio Mal");
                Operation.ResultObject = model;
                Operation.Ok = false;
            };
            return Operation;
        }

        public OperationResult<Estudiante> UpdateEstudiante(Estudiante model)
        {
            var Operation = new OperationResult<Estudiante>();

            var estudianteTracking = _GestionDB.Estudiantes.SingleOrDefault(x => x.Id_Estudiantes.Equals(model.Id_Estudiantes));
            try
            {
                _GestionDB.Estudiantes.Attach(model);
                _GestionDB.Entry(model).State = EntityState.Modified;
                _GestionDB.SaveChanges();
                Operation.Mensaje.Add("Success");
                Operation.ResultObject = model;
                Operation.Ok = true;
            }
            catch (Exception)
            {
                Operation.Mensaje.Add(" Revisa hubo un error al actualizar");
                Operation.ResultObject = model;
                Operation.Ok = false;
            }
            return Operation;

        }

        public OperationResult<Estudiante> DesativadoLogicoEstudiante(Estudiante model)
        {
            var Operation = new OperationResult<Estudiante>();

            var estudianteTracking = _GestionDB.Estudiantes.Find(model.Id_Estudiantes);
            try
            {
                estudianteTracking.IsActive = model.IsActive;
                _GestionDB.SaveChanges();
                Operation.Mensaje.Add("Success");
                Operation.ResultObject = model;
                Operation.Ok = true;

            }
            catch (Exception)
            {
                Operation.Mensaje.Add(" Ocurrio un problema");
                Operation.ResultObject = model;
                Operation.Ok = false;
            }
            return Operation;
        }
    }
}

