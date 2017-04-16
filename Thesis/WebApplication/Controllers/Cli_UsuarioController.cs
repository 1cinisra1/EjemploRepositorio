using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class Cli_UsuarioController : Controller
    {
        //
        // GET: /Cli_Usuario/

        bd_ControlVisitasEntities CliUsuarios = new bd_ControlVisitasEntities();       
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cli_VerUsuarios()
        {
            var listaUsuarios =CliUsuarios.cli_usuario;
            return View(listaUsuarios.ToList());
        }

        public ActionResult Cli_AgregaUsuario()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cli_AgregaUsuario(Cli_Usuario user)
        {
            return RedirectToAction("Cli_VerUsuarios", "Cli_Usuario");
            //return View();
        }
	}
}