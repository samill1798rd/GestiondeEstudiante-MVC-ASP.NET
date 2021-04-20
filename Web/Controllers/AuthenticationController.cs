using System.Web.Mvc;
using Web.ViewModel;

namespace Web.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Login()
        {
            return View();
            
        }


        public ActionResult Register()
        {
            return View();
        }


   
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Register(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return View();
        }
    }
}