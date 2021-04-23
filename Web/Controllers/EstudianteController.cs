﻿using AutoMapper;
using DataAccess;
using Services.EstudianteServices;
using System.Collections.Generic;
using System.Web.Mvc;
using Web.ViewModel;

namespace Web.Controllers
{
    public class EstudianteController : Controller
    {
        private IEstudianteServices _EstudianteServices;
        public EstudianteController(IEstudianteServices EstudianteServices)
        {
            _EstudianteServices = EstudianteServices;
        }

        [HttpGet]
        public ActionResult Index()
        {

            //var test = _EstudianteServices.GetallEstudiantes();
            //var ModelEstuidante = _EstudianteServices.GetEstudianteById(1);
            //var vm = MapperEstuidanteToViewModel(ModelEstuidante);
            var estudiantes = _EstudianteServices.GetallEstudiantes();
            var estufiatesViewModel = Mapper.Map<IEnumerable<EstudianteViewModel>>(estudiantes);
            //var model 
            //var save = _EstudianteServices.SaveEstudiante();
            return View(estufiatesViewModel);
        }

        [HttpGet]
        public ActionResult Save()
        {
          
            return View();
        }



        [HttpPost]
        public ActionResult Save(EstudianteViewModel vm)
        {
            var model = MapperViewModelToEstuidante(vm);
            var save = _EstudianteServices.SaveEstudiante(model);
            return View();
        }

        public ActionResult Update(EstudianteServices vm)
        {
            var ups = new EstudianteServices();
              
            return View();
        }


        public ActionResult IsActive(EstudianteViewModel vm)
        {
            var tmp = new EstudianteServices();

            return View();
        }

        private EstudianteViewModel MapperEstuidanteToViewModel(Estudiante model)
        {
            return new EstudianteViewModel()
            {
                Id_Estudiantes = model.Id_Estudiantes,
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                FechaNacimiento = model.FechaNacimiento,
                Imagen = model.Imagen,
                Matricula = model.Matricula,
                Nacionalidad_id = model.Nacionalidad_id,
                Carrera = model.Carrera,
                FechaInicio = model.FechaInicio,
                FechaFinalizacion = model.FechaFinalizacion,
                IsActive = model.IsActive,
                nacionalidad = model.nacionalidad
            };
        }
        //este metodo hace un mapping
        private Estudiante MapperViewModelToEstuidante(EstudianteViewModel vm)
        {
            return new Estudiante()
            {
                Id_Estudiantes = vm.Id_Estudiantes,
                Nombre = vm.Nombre != null ? vm.Nombre : null,
                Apellido = vm.Apellido,
                FechaNacimiento = vm.FechaNacimiento,
                Imagen = vm.Imagen,
                Matricula = vm.Matricula,
                Nacionalidad_id = vm.Nacionalidad_id,
                Carrera = vm.Carrera,
                FechaInicio = vm.FechaInicio,
                FechaFinalizacion = vm.FechaFinalizacion,
                IsActive = vm.IsActive,
                nacionalidad = vm.nacionalidad
            };
        }
    }
}


