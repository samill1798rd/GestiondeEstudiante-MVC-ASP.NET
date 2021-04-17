using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginCRUD.Models;
using LoginCRUD.Controllers;
using System.Data.SqlClient;

namespace LoginCRUD.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        void ConnetionString()
        {
            con.ConnectionString = @"data source=LAPTOP-CV-2O729\SQLEXPRESS; database=GestionBD; integrated security = SSPI;";
        }

        [HttpPost]
        public ActionResult Verificar(Account user, string mensaje)
        {
            
            ConnetionString();
            con.Open();
            com.Connection = con;
            com.CommandText = $"select * from Usuario where NombreUsuario ='{user.NombreUsuario}' and Clave='{user.Clave}'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return RedirectToAction("Index","Estudiantes");
            }
            else
            {
                con.Close();
                return View();
            }

        }

        public ActionResult SingUp(string mensaje = "")
        {
            ViewBag.Mensaje = mensaje;
            return View("Singup");
        }

        [HttpPost]
        public ActionResult Registrer(Account ac)
        {
            ac.FechaCreacion = DateTime.Now.ToString("yyyy-MM-dd");
            ConnetionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "INSERT INTO Usuario values ( '" + ac.NombreUsuario + "', '" + ac.Clave + "', '" + ac.FechaCreacion + "', 1)";
            com.ExecuteNonQuery();
            con.Close();
            return SingUp("Usuario Creado!");

        }
    }
}