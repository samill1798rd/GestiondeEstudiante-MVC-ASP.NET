using Services.EstudianteServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private IEstudianteServices _EstudianteServices;
        public HomeController(IEstudianteServices EstudianteServices)
        {
            _EstudianteServices = EstudianteServices;
        }

        public ActionResult Index()
        {
            var test = _EstudianteServices.GetallEstudiantes();
            var test2 = _EstudianteServices.GetEstudianteById(1);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}