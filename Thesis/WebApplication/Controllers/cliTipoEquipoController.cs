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
    public class cliTipoEquipoController : Controller
    {
        private bd_ControlVisitasEntities db = new bd_ControlVisitasEntities();

        // GET: /cliTipoEquipo/
        public async Task<ActionResult> Index()
        {
            if (Session["LogedUserID"] != null)
            {
                return View(await db.cli_tipoequipo.ToListAsync());
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // GET: /cliTipoEquipo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //string[] splitId = id.(',');
            cli_tipoequipo cli_tipoequipo = await db.cli_tipoequipo.FindAsync(id);
            if (cli_tipoequipo == null)
            {
                return HttpNotFound();
            }
            return View(cli_tipoequipo);
        }

        // GET: /cliTipoEquipo/Create
        public ActionResult Create()
        {
            if (Session["LogedUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // POST: /cliTipoEquipo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="idCli_TipoEquipo,cli_tipoequipoDesc")] cli_tipoequipo cli_tipoequipo)
        {
            if (ModelState.IsValid)
            {
                db.cli_tipoequipo.Add(cli_tipoequipo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cli_tipoequipo);
        }

        // GET: /cliTipoEquipo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cli_tipoequipo cli_tipoequipo = await db.cli_tipoequipo.FindAsync(id);
            if (cli_tipoequipo == null)
            {
                return HttpNotFound();
            }
            return View(cli_tipoequipo);
        }

        // POST: /cliTipoEquipo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="idCli_TipoEquipo,cli_tipoequipoDesc")] cli_tipoequipo cli_tipoequipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cli_tipoequipo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cli_tipoequipo);
        }

        // GET: /cliTipoEquipo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cli_tipoequipo cli_tipoequipo = await db.cli_tipoequipo.FindAsync(id);
            if (cli_tipoequipo == null)
            {
                return HttpNotFound();
            }
            return View(cli_tipoequipo);
        }

        // POST: /cliTipoEquipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            cli_tipoequipo cli_tipoequipo = await db.cli_tipoequipo.FindAsync(id);
            db.cli_tipoequipo.Remove(cli_tipoequipo);
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
