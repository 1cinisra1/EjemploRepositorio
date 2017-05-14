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
    public class cliClienteController : Controller
    {
        private bd_ControlVisitasEntities db = new bd_ControlVisitasEntities();

        // GET: /cliCliente/
        public async Task<ActionResult> Index()
        {
            if (Request.IsAuthenticated)
            {
                if (User.IsInRole("1"))
                {
                    ViewBag.Verificar = 18;
                    return View(await db.cli_cliente.ToListAsync());
                }
                ViewBag.Verificar = "String";
                return View();
            }
            return RedirectToAction("Login", "MyAccount");
        }

        // GET: /cliCliente/Details/5
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
                cli_cliente cli_cliente = await db.cli_cliente.FindAsync(id);
                if (cli_cliente == null)
                {
                    return HttpNotFound();
                }
                return View(cli_cliente);
            }
            ViewBag.Verificar = "String";
            return View();
            }
             return RedirectToAction("Login", "MyAccount");
        }

        // GET: /cliCliente/Create
        public ActionResult Create()
        {  if (Request.IsAuthenticated)
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

        // POST: /cliCliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="idCli_Cliente,Cli_Nombre,Cli_Ruc,Cli_Direccion,Cli_Tel,Cli_Ciudad,Cli_RSocial,Cli_NombContacto")] cli_cliente cli_cliente)
        {
            if (ModelState.IsValid)
            {
                db.cli_cliente.Add(cli_cliente);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Verificar = 18;
            return View(cli_cliente);
        }

        // GET: /cliCliente/Edit/5
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
                cli_cliente cli_cliente = await db.cli_cliente.FindAsync(id);
                if (cli_cliente == null)
                {
                    return HttpNotFound();
                }
               
                return View(cli_cliente);
            }
            ViewBag.Verificar = "String";
            return View();
            }
             return RedirectToAction("Login", "MyAccount");
        }

        // POST: /cliCliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="idCli_Cliente,Cli_Nombre,Cli_Ruc,Cli_Direccion,Cli_Tel,Cli_Ciudad,Cli_RSocial,Cli_NombContacto")] cli_cliente cli_cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cli_cliente).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cli_cliente);
        }

        // GET: /cliCliente/Delete/5
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
                cli_cliente cli_cliente = await db.cli_cliente.FindAsync(id);
                if (cli_cliente == null)
                {
                    return HttpNotFound();
                }
                
                return View(cli_cliente);
            }
            ViewBag.Verificar = "String";
            return View();
            }
             return RedirectToAction("Login", "MyAccount");
        }

        // POST: /cliCliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            cli_cliente cli_cliente = await db.cli_cliente.FindAsync(id);
            db.cli_cliente.Remove(cli_cliente);
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
