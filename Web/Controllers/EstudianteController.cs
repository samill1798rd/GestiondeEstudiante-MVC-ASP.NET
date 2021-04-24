using AutoMapper;
using DataAccess;
using Services.EstudianteServices;
using Services.NacionalidadServices;
using System.Collections.Generic;
using System.Web.Mvc;
using Web.ViewModel;
using System.Linq;

namespace Web.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly IEstudianteServices _estudianteServices;
        private readonly INacionaliadadService _nacionaliadadService;
        public EstudianteController(IEstudianteServices EstudianteServices,
                                    INacionaliadadService nacionaliadadService)
        {
            _estudianteServices = EstudianteServices;
            _nacionaliadadService = nacionaliadadService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var estudiantes = _estudianteServices.GetallEstudiantes();
            var estufiatesViewModel = Mapper.Map<IEnumerable<EstudianteViewModel>>(estudiantes);
            return View(estufiatesViewModel);
        }

        [HttpGet]
        public ActionResult Save()
        {
            ViewData["Nacionalidades"] = GetNacionalidadesViewModel();
            return View();
        }

        [HttpPost]
        public ActionResult Save(EstudianteViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var model = MapperViewModelToEstuidante(vm);
                model.IsActive = true;
                _estudianteServices.SaveEstudiante(model);
                return RedirectToAction(nameof(Index));
            }
            ViewData["Nacionalidades"] = GetNacionalidadesViewModel();
            return View();
        }

        private IEnumerable<NacionalidadesViewModel> GetNacionalidadesViewModel()
        {
            var nacionalidades = _nacionaliadadService.GetAllNacionalidades();
            var nacionalidadesViewModel = Mapper.Map<IEnumerable<NacionalidadesViewModel>>(nacionalidades);
            return nacionalidadesViewModel;
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


