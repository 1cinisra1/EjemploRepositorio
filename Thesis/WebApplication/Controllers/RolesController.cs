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
    public class rolesController : Controller
    {
        private bd_ControlVisitasEntities db = new bd_ControlVisitasEntities();

        // GET: /roles/
        public async Task<ActionResult> Index()
        {if (Request.IsAuthenticated)
            {
                if (User.IsInRole("1"))
                {
                    ViewBag.Verificar = 18;
            return View(await db.roles.ToListAsync());
                }
                ViewBag.Verificar = "String";
                return View();
            }
        return RedirectToAction("Login", "MyAccount");
        }

        // GET: /roles/Details/5
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
            roles roles = await db.roles.FindAsync(id);
            if (roles == null)
            {
                return HttpNotFound();
            }
            return View(roles);
            }
            ViewBag.Verificar = "String";
            return View();
            }
             return RedirectToAction("Login", "MyAccount");
        }

        // GET: /roles/Create
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

        // POST: /roles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="idRoles,Descripcion")] roles roles)
        {
            if (ModelState.IsValid)
            {
                db.roles.Add(roles);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Verificar = 18;
            return View(roles);
        }

        // GET: /roles/Edit/5
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
            roles roles = await db.roles.FindAsync(id);
            if (roles == null)
            {
                return HttpNotFound();
            }
            return View(roles);
            }
            ViewBag.Verificar = "String";
            return View();
            }
             return RedirectToAction("Login", "MyAccount");
        }

        // POST: /roles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="idRoles,Descripcion")] roles roles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roles).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Verificar = 18;
            return View(roles);
        }

        // GET: /roles/Delete/5
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
            roles roles = await db.roles.FindAsync(id);
            if (roles == null)
            {
                return HttpNotFound();
            }
            return View(roles);
            }
            ViewBag.Verificar = "String";
            return View();
            }
             return RedirectToAction("Login", "MyAccount");
        }

        // POST: /roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            roles roles = await db.roles.FindAsync(id);
            db.roles.Remove(roles);
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
