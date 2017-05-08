﻿using System;
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
    public class CompRutaController : Controller
    {
        private bd_ControlVisitasEntities db = new bd_ControlVisitasEntities();

        // GET: /CompRuta/
        public async Task<ActionResult> Index()
        {
            var comp_ruta = db.comp_ruta.Include(c => c.cli_cliente);
            return View(await comp_ruta.ToListAsync());
        }

        // GET: /CompRuta/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comp_ruta comp_ruta = await db.comp_ruta.FindAsync(id);
            if (comp_ruta == null)
            {
                return HttpNotFound();
            }
            return View(comp_ruta);
        }

        // GET: /CompRuta/Create
        public ActionResult Create()
        {
            ViewBag.Cli_Cliente_idCli_Cliente = new SelectList(db.cli_cliente, "idCli_Cliente", "Cli_Nombre");
            ViewBag.Cli_Usuario_idCli_Usuario = new SelectList(db.cli_usuario, "idCli_Usuario", "Cli_nombre");
            ViewBag.Com_Usuarios_idCom_Usuarios = new SelectList(db.com_usuarios, "idCom_Usuarios", "Com_Nombre");
            return View();
        }

        // POST: /CompRuta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="idComp_Bitacora,Comp_Fecha,Comp_NumeroVisitaMes,Comp_TiempoDur,Comp_Comentario,Comp_estado,Comp_HoraLlegada,Comp_HoraSalida,Comp_CreadoPor,Comp_CerradoPor,Com_Usuarios_idCom_Usuarios,Cli_Cliente_idCli_Cliente,Cli_Usuario_idCli_Usuario")] comp_ruta comp_ruta)
        {
            if (ModelState.IsValid)
            {
                db.comp_ruta.Add(comp_ruta);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Cli_Cliente_idCli_Cliente = new SelectList(db.cli_cliente, "idCli_Cliente", "Cli_Nombre", comp_ruta.Cli_Cliente_idCli_Cliente);
            return View(comp_ruta);
        }

        // GET: /CompRuta/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comp_ruta comp_ruta = await db.comp_ruta.FindAsync(id);
            if (comp_ruta == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cli_Cliente_idCli_Cliente = new SelectList(db.cli_cliente, "idCli_Cliente", "Cli_Nombre", comp_ruta.Cli_Cliente_idCli_Cliente);
            return View(comp_ruta);
        }

        // POST: /CompRuta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="idComp_Bitacora,Comp_Fecha,Comp_NumeroVisitaMes,Comp_TiempoDur,Comp_Comentario,Comp_estado,Comp_HoraLlegada,Comp_HoraSalida,Comp_CreadoPor,Comp_CerradoPor,Com_Usuarios_idCom_Usuarios,Cli_Cliente_idCli_Cliente,Cli_Usuario_idCli_Usuario")] comp_ruta comp_ruta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comp_ruta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Cli_Cliente_idCli_Cliente = new SelectList(db.cli_cliente, "idCli_Cliente", "Cli_Nombre", comp_ruta.Cli_Cliente_idCli_Cliente);
            return View(comp_ruta);
        }

        // GET: /CompRuta/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comp_ruta comp_ruta = await db.comp_ruta.FindAsync(id);
            if (comp_ruta == null)
            {
                return HttpNotFound();
            }
            return View(comp_ruta);
        }

        // POST: /CompRuta/Delete/5
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
