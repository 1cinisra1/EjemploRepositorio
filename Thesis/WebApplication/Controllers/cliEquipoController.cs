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
    public class cliEquipoController : Controller
    {
        private bd_ControlVisitasEntities db = new bd_ControlVisitasEntities();

        // GET: /cliEquipo/
        public async Task<ActionResult> Index()
        {
             if (Request.IsAuthenticated)
            {
                if (User.IsInRole("1"))
                {
                    ViewBag.Verificar = 18;
            var cli_equipo = db.cli_equipo.Include(c => c.cli_tipoequipo1);
            return View(await cli_equipo.ToListAsync());
                }
                ViewBag.Verificar = "String";
                return View();
            }
             return RedirectToAction("Login", "MyAccount");
        }

        // GET: /cliEquipo/Details/5
        public async Task<ActionResult> Details(int? id,int? id1)
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
            cli_equipo cli_equipo = await db.cli_equipo.FindAsync(id,id1);
            if (cli_equipo == null)
            {
                return HttpNotFound();
            }
            return View(cli_equipo);
            }
            ViewBag.Verificar = "String";
            return View();
            }
              return RedirectToAction("Login", "MyAccount");
        }

        // GET: /cliEquipo/Create
        public ActionResult Create()
        {
             if (Request.IsAuthenticated)
            {
            if (User.IsInRole("1"))
            {
                ViewBag.Verificar = 18;
            ViewBag.Cli_TipoEquipo_idCli_TipoEquipo = new SelectList(db.cli_tipoequipo, "idCli_TipoEquipo", "Cli_Descripcion");
            return View();
            }
            ViewBag.Verificar = "String";
            return View();
            }
             return RedirectToAction("Login", "MyAccount");
        }

        // POST: /cliEquipo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="idCli_Equipo,Cli_Marca,Cli_Modelo,Cli_DiscoDuro,Cli_Ram,Cli_Procesador,Cli_TipoEquipo,Cli_TipoEquipo_idCli_TipoEquipo")] cli_equipo cli_equipo)
        {
            if (ModelState.IsValid)
            {
                db.cli_equipo.Add(cli_equipo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Cli_TipoEquipo_idCli_TipoEquipo = new SelectList(db.cli_tipoequipo, "idCli_TipoEquipo", "Cli_Descripcion", cli_equipo.Cli_TipoEquipo_idCli_TipoEquipo);
            return View(cli_equipo);
        }

        // GET: /cliEquipo/Edit/5
        public async Task<ActionResult> Edit(int? id,int? id1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             if (Request.IsAuthenticated)
            {
            if (User.IsInRole("1"))
            {
            cli_equipo cli_equipo = await db.cli_equipo.FindAsync(id,id1);
            if (cli_equipo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cli_TipoEquipo_idCli_TipoEquipo = new SelectList(db.cli_tipoequipo, "idCli_TipoEquipo", "Cli_Descripcion", cli_equipo.Cli_TipoEquipo_idCli_TipoEquipo);
            ViewBag.Verificar = 18;
            return View(cli_equipo);
            }
            ViewBag.Verificar = "String";
            return View();
            }
             return RedirectToAction("Login", "MyAccount");
        }

        // POST: /cliEquipo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="idCli_Equipo,Cli_Marca,Cli_Modelo,Cli_DiscoDuro,Cli_Ram,Cli_Procesador,Cli_TipoEquipo,Cli_TipoEquipo_idCli_TipoEquipo")] cli_equipo cli_equipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cli_equipo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Cli_TipoEquipo_idCli_TipoEquipo = new SelectList(db.cli_tipoequipo, "idCli_TipoEquipo", "Cli_Descripcion", cli_equipo.Cli_TipoEquipo_idCli_TipoEquipo);
            return View(cli_equipo);
        }

        // GET: /cliEquipo/Delete/5
        public async Task<ActionResult> Delete(int? id,int? id1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (Request.IsAuthenticated)
            {
                if (User.IsInRole("1"))
                {
                    cli_equipo cli_equipo = await db.cli_equipo.FindAsync(id,id1);
                    if (cli_equipo == null)
                    {
                        return HttpNotFound();
                    }
                        ViewBag.Verificar = 18;
                    return View(cli_equipo);
                }
                ViewBag.Verificar = "String";
                return View();
            }
            return RedirectToAction("Login", "MyAccount");
        }

        // POST: /cliEquipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id, int id1)
        {
            cli_equipo cli_equipo = await db.cli_equipo.FindAsync(id,id1);
            db.cli_equipo.Remove(cli_equipo);
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
