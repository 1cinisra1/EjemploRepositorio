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
    public class cliUserController : Controller
    {
        private bd_ControlVisitasEntities db = new bd_ControlVisitasEntities();

        // GET: /cliUser/
        public async Task<ActionResult> Index()
        {
             if (Request.IsAuthenticated)
            {
                if (User.IsInRole("1"))
                {
                ViewBag.Verificar = 18;
                var cli_user = db.cli_user.Include(c => c.cli_cliente).Include(c => c.cli_departamento).Include(c => c.cli_equipo);
                return View(await cli_user.ToListAsync());
                }
                ViewBag.Verificar = "String";
                return View();
            }
             return RedirectToAction("Login", "MyAccount");
        }

        // GET: /cliUser/Details/5
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
            cli_user cli_user = await db.cli_user.FindAsync(id);
            if (cli_user == null)
            {
                return HttpNotFound();
            }
            return View(cli_user);
            }
            ViewBag.Verificar = "String";
            return View();
            }
             return RedirectToAction("Login", "MyAccount");
        }

        // GET: /cliUser/Create
        public ActionResult Create()
        {
            if (Request.IsAuthenticated)
            {
            if (User.IsInRole("1"))
            {
            ViewBag.Verificar = 18;
            ViewBag.Cli_Cliente_idCli_Cliente = new SelectList(db.cli_cliente, "idCli_Cliente", "Cli_Nombre");
            ViewBag.Cli_Departamento_idCli_Departamento = new SelectList(db.cli_departamento, "idCli_Departamento", "Cli_Descripcion");
            ViewBag.Cli_Equipo_idCli_Equipo = new SelectList(db.cli_equipo, "idCli_Equipo", "Cli_Marca");
            ViewBag.Cli_Equipo_Cli_TipoEquipo_idCli_TipoEquipo = new SelectList(db.cli_tipoequipo, "idCli_TipoEquipo", "Cli_Descripcion");
            return View();
            }
            ViewBag.Verificar = "String";
            return View();
            }
            return RedirectToAction("Login", "MyAccount");
        }

        // POST: /cliUser/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="idCli_Usuario,Cli_nombre,Cli_apellido,Cli_Correo,Cli_Equipo_idCli_Equipo,Cli_Equipo_Cli_TipoEquipo_idCli_TipoEquipo,Cli_Cliente_idCli_Cliente,Cli_Departamento_idCli_Departamento")] cli_user cli_user)
        {
            if (ModelState.IsValid)
            {
                db.cli_user.Add(cli_user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //ViewBag.Verificar = 18;
            ViewBag.Cli_Cliente_idCli_Cliente = new SelectList(db.cli_cliente, "idCli_Cliente", "Cli_Nombre", cli_user.Cli_Cliente_idCli_Cliente);
            ViewBag.Cli_Departamento_idCli_Departamento = new SelectList(db.cli_departamento, "idCli_Departamento", "Cli_Descripcion", cli_user.Cli_Departamento_idCli_Departamento);
            ViewBag.Cli_Equipo_idCli_Equipo = new SelectList(db.cli_equipo, "idCli_Equipo", "Cli_Marca", cli_user.Cli_Equipo_idCli_Equipo);
            return View(cli_user);
        }

        // GET: /cliUser/Edit/5
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
            cli_user cli_user = await db.cli_user.FindAsync(id);
            ViewBag.Verificar = 18;
            if (cli_user == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cli_Cliente_idCli_Cliente = new SelectList(db.cli_cliente, "idCli_Cliente", "Cli_Nombre", cli_user.Cli_Cliente_idCli_Cliente);
            ViewBag.Cli_Departamento_idCli_Departamento = new SelectList(db.cli_departamento, "idCli_Departamento", "Cli_Descripcion", cli_user.Cli_Departamento_idCli_Departamento);
            ViewBag.Cli_Equipo_idCli_Equipo = new SelectList(db.cli_equipo, "idCli_Equipo", "Cli_Marca", cli_user.Cli_Equipo_idCli_Equipo);
            return View(cli_user);
            }
            ViewBag.Verificar = "String";
            return View();
            }
             return RedirectToAction("Login", "MyAccount");
        }

        // POST: /cliUser/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="idCli_Usuario,Cli_nombre,Cli_apellido,Cli_Correo,Cli_Equipo_idCli_Equipo,Cli_Equipo_Cli_TipoEquipo_idCli_TipoEquipo,Cli_Cliente_idCli_Cliente,Cli_Departamento_idCli_Departamento")] cli_user cli_user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cli_user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Verificar = 18;
            ViewBag.Cli_Cliente_idCli_Cliente = new SelectList(db.cli_cliente, "idCli_Cliente", "Cli_Nombre", cli_user.Cli_Cliente_idCli_Cliente);
            ViewBag.Cli_Departamento_idCli_Departamento = new SelectList(db.cli_departamento, "idCli_Departamento", "Cli_Descripcion", cli_user.Cli_Departamento_idCli_Departamento);
            ViewBag.Cli_Equipo_idCli_Equipo = new SelectList(db.cli_equipo, "idCli_Equipo", "Cli_Marca", cli_user.Cli_Equipo_idCli_Equipo);
            return View(cli_user);
        }

        // GET: /cliUser/Delete/5
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
                cli_cliente cli_cliente = await db.cli_cliente.FindAsync(id);
                ViewBag.Verificar = 18;
            cli_user cli_user = await db.cli_user.FindAsync(id);
            if (cli_user == null)
            {
                return HttpNotFound();
            }
            return View(cli_user);
            }
            ViewBag.Verificar = "String";
            return View();
            }
             return RedirectToAction("Login", "MyAccount");
        }

        // POST: /cliUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            cli_user cli_user = await db.cli_user.FindAsync(id);
            db.cli_user.Remove(cli_user);
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
