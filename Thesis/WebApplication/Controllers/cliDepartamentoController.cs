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
    public class cliDepartamentoController : Controller
    {
        private bd_ControlVisitasEntities db = new bd_ControlVisitasEntities();

        // GET: /cliDepartamento/
        public async Task<ActionResult> Index()
        {
             if (Request.IsAuthenticated)
            {
                if (User.IsInRole("1"))
                {
                     ViewBag.Verificar = 18;
                     return View(await db.cli_departamento.ToListAsync());
                }
                ViewBag.Verificar = "String";
                return View();
            }
             return RedirectToAction("Login", "MyAccount");
        }

        // GET: /cliDepartamento/Details/5
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
            cli_departamento cli_departamento = await db.cli_departamento.FindAsync(id);
            if (cli_departamento == null)
            {
                return HttpNotFound();
            }
            return View(cli_departamento);
                }
                ViewBag.Verificar = "String";
                return View();
            }
              return RedirectToAction("Login", "MyAccount");
        }

        // GET: /cliDepartamento/Create
        public ActionResult Create()
        {
            if (Request.IsAuthenticated)
            {
                if (User.IsInRole("1"))
                {
                    ViewBag.Verificar = 18;
                    return View();
                }
                ViewBag.Verificar = "String";
                return View();
            }
            return RedirectToAction("Login", "MyAccount");
        }

        // POST: /cliDepartamento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="idCli_Departamento,Cli_Descripcion")] cli_departamento cli_departamento)
        {
            if (ModelState.IsValid)
            {
                db.cli_departamento.Add(cli_departamento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cli_departamento);
        }

        // GET: /cliDepartamento/Edit/5
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
            cli_departamento cli_departamento = await db.cli_departamento.FindAsync(id);
            if (cli_departamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.Verificar = 18;
            return View(cli_departamento);
            }
            ViewBag.Verificar = "String";
            return View();
            }
            return RedirectToAction("Login", "MyAccount");
        }

        // POST: /cliDepartamento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="idCli_Departamento,Cli_Descripcion")] cli_departamento cli_departamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cli_departamento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cli_departamento);
        }

        // GET: /cliDepartamento/Delete/5
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
            cli_departamento cli_departamento = await db.cli_departamento.FindAsync(id);
            if (cli_departamento == null)
            {
                return HttpNotFound();
            }
             ViewBag.Verificar = 18;
            return View(cli_departamento);
            }
            ViewBag.Verificar = "String";
            return View();
            }
            return RedirectToAction("Login", "MyAccount");
        }

        // POST: /cliDepartamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            cli_departamento cli_departamento = await db.cli_departamento.FindAsync(id);
            db.cli_departamento.Remove(cli_departamento);
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
