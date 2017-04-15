using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class Cli_UsuarioController : Controller
    {
        //
        // GET: /Cli_Usuario/

        List<Cli_Usuario> listUsr = new List<Cli_Usuario>();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cli_VerUsuarios()
        {
            return View(listUsr);
        }

        public ActionResult Cli_AgregaUsuario()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cli_AgregaUsuario(Cli_Usuario user)
        {
            listUsr.Add(user);
            return RedirectToAction("Cli_VerUsuarios", "Cli_Usuario");
            //return View();
        }
	}
}