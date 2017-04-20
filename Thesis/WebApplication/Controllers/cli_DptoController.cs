using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class cli_DptoController : Controller
    {
        private bd_ControlVisitasEntities db = new bd_ControlVisitasEntities();

        // GET: /cli_Dpto/
        public ActionResult Index()
        {
            if (Session["LogedUserID"] != null)
            {
                return View(db.cli_departamento.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // GET: /cli_Dpto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cli_departamento cli_departamento = db.cli_departamento.Find(id);
            if (cli_departamento == null)
            {
                return HttpNotFound();
            }
            return View(cli_departamento);
        }

        // GET: /cli_Dpto/Create
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

        // POST: /cli_Dpto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="idCli_Departamento,Cli_Descripcion")] cli_departamento cli_departamento)
        {
            if (ModelState.IsValid)
            {
                db.cli_departamento.Add(cli_departamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cli_departamento);
        }

        // GET: /cli_Dpto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cli_departamento cli_departamento = db.cli_departamento.Find(id);
            if (cli_departamento == null)
            {
                return HttpNotFound();
            }
            return View(cli_departamento);
        }

        // POST: /cli_Dpto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idCli_Departamento,Cli_Descripcion")] cli_departamento cli_departamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cli_departamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cli_departamento);
        }

        // GET: /cli_Dpto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cli_departamento cli_departamento = db.cli_departamento.Find(id);
            if (cli_departamento == null)
            {
                return HttpNotFound();
            }
            return View(cli_departamento);
        }

        // POST: /cli_Dpto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cli_departamento cli_departamento = db.cli_departamento.Find(id);
            db.cli_departamento.Remove(cli_departamento);
            db.SaveChanges();
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
