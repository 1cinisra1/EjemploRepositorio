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
    public class cliUsuarioController : Controller
    {
        private bd_ControlVisitasEntities db = new bd_ControlVisitasEntities();

        // GET: /cliUsuario/
        public async Task<ActionResult> Index()
        {
            if (Session["LogedUserID"] != null)
            {
                var cli_usuario = db.cli_usuario.Include(c => c.cli_departamento1).Include(c => c.cli_empresa);
                return View(await cli_usuario.ToListAsync());
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }            
        }

        // GET: /cliUsuario/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cli_usuario cli_usuario = await db.cli_usuario.FindAsync(id);
            if (cli_usuario == null)
            {
                return HttpNotFound();
            }
            return View(cli_usuario);
        }

        // GET: /cliUsuario/Create
        public ActionResult Create()
        {
            if (Session["LogedUserID"] != null)
            {
                ViewBag.Cli_Departamento_idCli_Departamento = new SelectList(db.cli_departamento, "idCli_Departamento", "Cli_Descripcion");
                ViewBag.Cli_Empresa_idCli_Empresa = new SelectList(db.cli_empresa, "idCli_Empresa", "Cli_Nombre");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // POST: /cliUsuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="idCli_Usuario,Cli_Departamento_idCli_Departamento,Cli_Equipo_idCli_Equipo,Cli_Empresa_idCli_Empresa,Cli_nombre")] cli_usuario cli_usuario)
        {
            if (ModelState.IsValid)
            {
                db.cli_usuario.Add(cli_usuario);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Cli_Departamento_idCli_Departamento = new SelectList(db.cli_departamento, "idCli_Departamento", "Cli_Descripcion", cli_usuario.Cli_Departamento_idCli_Departamento);
            ViewBag.Cli_Empresa_idCli_Empresa = new SelectList(db.cli_empresa, "idCli_Empresa", "Cli_Nombre", cli_usuario.Cli_Empresa_idCli_Empresa);
            return View(cli_usuario);
        }

        // GET: /cliUsuario/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cli_usuario cli_usuario = await db.cli_usuario.FindAsync(id);
            if (cli_usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cli_Departamento_idCli_Departamento = new SelectList(db.cli_departamento, "idCli_Departamento", "Cli_Descripcion", cli_usuario.Cli_Departamento_idCli_Departamento);
            ViewBag.Cli_Empresa_idCli_Empresa = new SelectList(db.cli_empresa, "idCli_Empresa", "Cli_Nombre", cli_usuario.Cli_Empresa_idCli_Empresa);
            return View(cli_usuario);
        }

        // POST: /cliUsuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="idCli_Usuario,Cli_Departamento_idCli_Departamento,Cli_Equipo_idCli_Equipo,Cli_Empresa_idCli_Empresa,Cli_nombre")] cli_usuario cli_usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cli_usuario).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Cli_Departamento_idCli_Departamento = new SelectList(db.cli_departamento, "idCli_Departamento", "Cli_Descripcion", cli_usuario.Cli_Departamento_idCli_Departamento);
            ViewBag.Cli_Empresa_idCli_Empresa = new SelectList(db.cli_empresa, "idCli_Empresa", "Cli_Nombre", cli_usuario.Cli_Empresa_idCli_Empresa);
            return View(cli_usuario);
        }

        // GET: /cliUsuario/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cli_usuario cli_usuario = await db.cli_usuario.FindAsync(id);
            if (cli_usuario == null)
            {
                return HttpNotFound();
            }
            return View(cli_usuario);
        }

        // POST: /cliUsuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            cli_usuario cli_usuario = await db.cli_usuario.FindAsync(id);
            db.cli_usuario.Remove(cli_usuario);
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
