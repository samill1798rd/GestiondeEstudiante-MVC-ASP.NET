﻿using Common;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EstudianteServices
{
    public class EstudianteServices : IEstudianteServices
    {
        private GestionDB _GestionDB;
        public EstudianteServices()
        {
            _GestionDB = new GestionDB();
        }

        public List<Estudiante> GetallEstudiantes()
        {
           var ListEstudiante =_GestionDB.Estudiantes
                                         .Include("nacionalidad")
                                         .OrderBy(x=>x.Nombre)
                                         .Where(x=>x.IsActive == true)
                                         .ToList();

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
            throw new NotImplementedException();
        }

        public OperationResult<Estudiante> DeleteEstudiante(Estudiante model)
        {
            throw new NotImplementedException();
        }
    }
}
