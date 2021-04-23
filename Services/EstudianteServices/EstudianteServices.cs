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
        private readonly GestionDB _GestionDB;
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
                Operation = SendModelStatus(model, true);
            }
            catch (Exception)
            {
                Operation = SendModelStatus(model, false);
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
                Operation = SendModelStatus(model, true);
            }
            catch (Exception)
            {
                Operation = SendModelStatus(model, false);
            }
            return Operation;
        }

        public OperationResult<Estudiante> DisableEstudiante(Estudiante model)
        {
            var Operation = new OperationResult<Estudiante>();

            var estudianteTracking = _GestionDB.Estudiantes.Find(model.Id_Estudiantes);
            try
            {
                estudianteTracking.IsActive = model.IsActive;
                _GestionDB.SaveChanges();
                Operation = SendModelStatus(model, true);
            }
            catch (Exception)
            {
                Operation = SendModelStatus(model, false);
            }
            return Operation;
        }

        private OperationResult<Estudiante> SendModelStatus(Estudiante model, bool status)
        {
            var Operation = new OperationResult<Estudiante>();
            Operation.Mensaje.Add(status.Equals(true) ? "Success" : "Error");
            Operation.ResultObject = model;
            Operation.Ok = status;

            return Operation;
        }
    }
}

