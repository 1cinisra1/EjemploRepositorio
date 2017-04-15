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

        MyappContext.MyappDataContext cliUser = new MyappContext.MyappDataContext();

        app
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cli_VerUsuarios()
        {
            var listaUsuarios = cliUser.CliUsuarios;
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