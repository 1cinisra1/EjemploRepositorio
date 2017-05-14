using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class compRutaController : Controller
    {
        private bd_ControlVisitasEntities db = new bd_ControlVisitasEntities();

        // GET: /compRuta/
        public async Task<ActionResult> Index()
        {
            if (Request.IsAuthenticated)
            {
                if (User.IsInRole("1"))
                {
                    ViewBag.Verificar = 18;
                    var comp_ruta = db.comp_ruta.Include(c => c.cli_user).Include(c => c.com_usuarios);
                    return View(await comp_ruta.ToListAsync());
                }
                ViewBag.Verificar = "String";
                return View();
            }
            return RedirectToAction("Login", "MyAccount");
        }

        // GET: /compRuta/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (Request.IsAuthenticated)
            {
            if (User.IsInRole("1"))
            {
                ViewBag.Verificar = 18;
            comp_ruta comp_ruta = await db.comp_ruta.FindAsync(id);
            if (comp_ruta == null)
            {
                return HttpNotFound();
            }
            return View(comp_ruta);
            }
            ViewBag.Verificar = "String";
            return View();
            }
            return RedirectToAction("Login", "MyAccount");
        }

        // GET: /compRuta/Create
        public ActionResult Create()
        {
            if (Request.IsAuthenticated)
            {
                if (User.IsInRole("1"))
                {
                    ViewBag.Verificar = 18;
                    ViewBag.Cli_Usuario_idCli_Usuario = new SelectList(db.cli_user, "idCli_Usuario", "Cli_nombre");
                    ViewBag.Com_Usuarios_idCom_Usuarios = new SelectList(db.com_usuarios.Where(item => item.Roles_idRoles == 2), "idCom_Usuarios", "Com_Nombre");
                    ViewBag.Com_Usuarios_Roles_idRoles = new SelectList(db.roles.Where(item => item.idRoles == 2), "idRoles", "Descripcion");
                    return View();
                }
                ViewBag.Verificar = "String";
                return View();
            }
        return RedirectToAction("Login", "MyAccount");
        }

        // POST: /compRuta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idComp_Bitacora,Comp_Fecha,Comp_NumeroVisitaMes,Comp_TiempoDur,Comp_Comentario,Comp_estado,Comp_HoraLlegada,Comp_HoraSalida,Comp_CreadoPor,Comp_CerradoPor,Com_Usuarios_idCom_Usuarios,Cli_Usuario_idCli_Usuario,Com_Usuarios_Roles_idRoles")] comp_ruta comp_ruta)
        {
            if (ModelState.IsValid)
            {
                db.comp_ruta.Add(comp_ruta);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Cli_Usuario_idCli_Usuario = new SelectList(db.cli_user, "idCli_Usuario", "Cli_nombre", comp_ruta.Cli_Usuario_idCli_Usuario);
            ViewBag.Com_Usuarios_idCom_Usuarios = new SelectList(db.com_usuarios, "idCom_Usuarios", "Com_Nombre", comp_ruta.Com_Usuarios_idCom_Usuarios);
            return View(comp_ruta);
        }

        // GET: /compRuta/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             if (Request.IsAuthenticated)
            {
            if (User.IsInRole("1"))
            {
                ViewBag.Verificar = 18;
            comp_ruta comp_ruta = await db.comp_ruta.FindAsync(id);
            if (comp_ruta == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cli_Usuario_idCli_Usuario = new SelectList(db.cli_user, "idCli_Usuario", "Cli_nombre", comp_ruta.Cli_Usuario_idCli_Usuario);
            ViewBag.Com_Usuarios_idCom_Usuarios = new SelectList(db.com_usuarios, "idCom_Usuarios", "Com_Nombre", comp_ruta.Com_Usuarios_idCom_Usuarios);
            ViewBag.Com_Usuarios_Roles_idRoles = new SelectList(db.roles, "idRoles", "Descripcion");
            return View(comp_ruta);
            }
            ViewBag.Verificar = "String";
            return View();
            }
             return RedirectToAction("Login", "MyAccount");
        }

        // POST: /compRuta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idComp_Bitacora,Comp_Fecha,Comp_NumeroVisitaMes,Comp_TiempoDur,Comp_Comentario,Comp_estado,Comp_HoraLlegada,Comp_HoraSalida,Comp_CreadoPor,Comp_CerradoPor,Com_Usuarios_idCom_Usuarios,Cli_Usuario_idCli_Usuario,Com_Usuarios_Roles_idRoles")] comp_ruta comp_ruta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comp_ruta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Cli_Usuario_idCli_Usuario = new SelectList(db.cli_user, "idCli_Usuario", "Cli_nombre", comp_ruta.Cli_Usuario_idCli_Usuario);
            ViewBag.Com_Usuarios_idCom_Usuarios = new SelectList(db.com_usuarios, "idCom_Usuarios", "Com_Nombre", comp_ruta.Com_Usuarios_idCom_Usuarios);
            return View(comp_ruta);
        }

        // GET: /compRuta/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             if (Request.IsAuthenticated)
            {
            if (User.IsInRole("1"))
            {
                ViewBag.Verificar = 18;
            comp_ruta comp_ruta = await db.comp_ruta.FindAsync(id);
            if (comp_ruta == null)
            {
                return HttpNotFound();
            }
            return View(comp_ruta);
            }
            ViewBag.Verificar = "String";
            return View();
            }
             return RedirectToAction("Login", "MyAccount");
        }

        // POST: /compRuta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            comp_ruta comp_ruta = await db.comp_ruta.FindAsync(id);
            db.comp_ruta.Remove(comp_ruta);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
