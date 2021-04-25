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
        public ActionResult Save(
            [Bind(Include = "Nombre,Apellido,FechaNacimiento,Matricula," +
            "Carrera,FechaInicio,FechaFinalizacion,Nacionalidad_id")] EstudianteViewModel vm)
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

        [HttpGet]
        public ActionResult Detail(int? Id_Estudiantes)
        {
            var estudiante = _estudianteServices.GetFullEstudianteById(Id_Estudiantes);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            var estudianteViewModel = Mapper.Map<EstudianteViewModel>(estudiante);
            return View(estudianteViewModel);
        }


        [HttpPost]
        public ActionResult Update(EstudianteViewModel vm)
        {
            ViewData["Nacionalidades"] = GetNacionalidadesViewModel();
            var estuidiante = Mapper.Map<Estudiante>(vm);
            if (ModelState.IsValid)
            {
                _estudianteServices.UpdateEstudiante(estuidiante);
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        [HttpGet]
        public ActionResult Update(int? Id_Estudiantes)
        {
            var estudiante = _estudianteServices.GetEstudianteById(Id_Estudiantes);
            ViewData["Nacionalidades"] = GetNacionalidadesViewModel();
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            var estudianteViewModel = Mapper.Map<EstudianteViewModel>(estudiante);
            return View(estudianteViewModel);
        }

        [HttpGet]
        public ActionResult Disabled(int? Id_Estudiantes)
        {
            var estudiante = _estudianteServices.GetEstudianteById(Id_Estudiantes);
            _estudianteServices.DisableEstudiante(estudiante);
            ViewData["Nacionalidades"] = GetNacionalidadesViewModel();
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            var estudianteViewModel = Mapper.Map<EstudianteViewModel>(estudiante);
            return RedirectToAction(nameof(Index));
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


