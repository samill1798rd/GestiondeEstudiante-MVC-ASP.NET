using Common;
using DataAccess;
using System;
using System.Linq;
using System.Web.Mvc;
using Web.ViewModel;
using Services.UserServices;

namespace Web.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserServices _userService;

        public AuthenticationController(IUserServices userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }

        public ActionResult Login()
        {
            if (Session["user_id"] != null)
            {
                return Redirect("~/Home");
            }

            ViewBag.Title = "Iniciar Sesión";
            return View();
        }

        public ActionResult Register()
        {
            if (Session["user_id"] != null)
            {
                return Redirect("~/Home");
            }

            ViewBag.Title = "Registro";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user =
                _userService
                .GetFirst(d => d.NombreUsuario.ToLower().Equals(loginViewModel.NombreUsuario));

            if (user != null && user.Clave.Equals(loginViewModel.Clave))
            {
                Session["user_id"] = user.Id_usuario;
                Session["username"] = user.NombreUsuario;

                return Redirect("~/");
            }

            ModelState.AddModelError("", "Ha digitado credenciales incorrectas. Vuelva a intentarlo");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user =
                _userService
                    .GetFirst(d =>
                        d.NombreUsuario.ToLower().Equals(usuarioViewModel.NombreUsuario)
                    )
                    ?? new Usuario();

            if (user.NombreUsuario != null)
            {
                ModelState.AddModelError("", "Este nombre de usuario ya existe");
                return View();
            }

            //Copiar propiedades del VM al Modelo
            Utils.CopyPropertiesTo(usuarioViewModel, user);
            user.IsActive = true;
            user.FechaCreacion = DateTime.Now;

            _userService.SaveUser(user);

            return RedirectToAction(nameof(Login));
        }

        [HttpPost]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction(nameof(Login));
        }
    }
}