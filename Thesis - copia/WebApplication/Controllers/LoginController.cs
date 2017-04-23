using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(com_usuarios u)
        {
            if (ModelState.IsValid)
            {
                using (bd_ControlVisitasEntities dc = new bd_ControlVisitasEntities())
                {
                    var v = dc.com_usuarios.Where(a => a.com_username.Equals(u.com_username) && a.com_clave.Equals(u.com_clave)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LogedUserID"] = v.idCom_Usuarios.ToString();
                        Session["LogedUserName"] = v.Com_Nombre.ToString();
                        return RedirectToAction("Listar","cliUsuario");
                    }
                }
            }
            return View(u);
        }

        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Register(com_usuarios u)
        {
            if (ModelState.IsValid)
            {
                using (bd_ControlVisitasEntities db = new bd_ControlVisitasEntities())
                {
                    db.com_usuarios.Add(u);
                    db.SaveChanges();
                    ModelState.Clear();
                    u = null;
                    ViewBag.Message = "Agregado";
                }
            }
            return View(u);
        }
	}
}