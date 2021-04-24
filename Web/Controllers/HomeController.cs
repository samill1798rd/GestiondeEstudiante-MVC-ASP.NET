using DataAccess;
using Services.EstudianteServices;
using System.Web.Mvc;
using Web.ViewModel;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
         //Aqui llamamos a los servivios del mantenimiento de estudiante que contiene la interfaz s
        private IEstudianteServices _EstudianteServices;
        public HomeController(IEstudianteServices EstudianteServices)
        {
            _EstudianteServices = EstudianteServices;
        }
        //Aqui va aparecer toda la informacion de los estudiantes llamados o mostrados a traves de su Id
        public ActionResult Index()
        {

            //var test = _EstudianteServices.GetallEstudiantes();
            var ModelEstuidante = _EstudianteServices.GetEstudianteById(1);
            var vm = MapperEstuidanteToViewModel(ModelEstuidante);

            //var model 

            //var save = _EstudianteServices.SaveEstudiante();

            return View(vm);
        }

        //Aqui se esta ejecutando la funcion para guardar los datos del estudiante conetado 
        //con el view model
        [HttpPost]
        public ActionResult Save(EstudianteViewModel vm)
        {
            var model = MapperViewModelToEstuidante(vm);
            var save = _EstudianteServices.SaveEstudiante(model);
            return View();
        }
        //Aqui se esta ejecutando la funcion para actualizar los datos del estudiante conetado 
        //con estudiante services para que llame sus datos que tiene dentro
        public ActionResult Update(EstudianteServices vm)
        {
            var ups = new EstudianteServices();
              
            return View();
        }

        //Aqui se esta ejecutando la funcion isActive de los estudiante conetado para no eliminarlo sino 
        // borrarlos
        public ActionResult IsActive(EstudianteViewModel vm)
        {
            var tmp = new EstudianteServices();

            return View();
        }

        //este metodo hace un mapping que viene del view moddel del estudiante directamente de su modelo 
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
        //este metodo hace un mapping que viene del view moddel del estudiante 
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


