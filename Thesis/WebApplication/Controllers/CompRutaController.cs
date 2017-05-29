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
using System.Net.Mail;

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
        public async Task<ActionResult> Create(comp_ruta comp_ruta)
        {
            if (ModelState.IsValid)
            {
                db.comp_ruta.Add(comp_ruta);
                await db.SaveChangesAsync();
                var emailTecnico = (from h in db.com_usuarios
                                    where h.idCom_Usuarios.Equals(comp_ruta.Com_Usuarios_idCom_Usuarios)
                                    select h.Com_Correo).SingleOrDefault();

                var nombreTecnico = (from h in db.com_usuarios
                                     where h.idCom_Usuarios.Equals(comp_ruta.Com_Usuarios_idCom_Usuarios)
                                     select h.Com_Nombre).SingleOrDefault();

                Email(comp_ruta.idComp_Bitacora, comp_ruta.Comp_CreadoPor, nombreTecnico.ToString(), emailTecnico.ToString());
                return RedirectToAction("Index");
            }
            ViewBag.Verificar = 18;
            ViewBag.Cli_Usuario_idCli_Usuario = new SelectList(db.cli_user, "idCli_Usuario", "Cli_nombre", comp_ruta.Cli_Usuario_idCli_Usuario);
            ViewBag.Com_Usuarios_idCom_Usuarios = new SelectList(db.com_usuarios, "idCom_Usuarios", "Com_Nombre", comp_ruta.Com_Usuarios_idCom_Usuarios);
            ViewBag.Com_Usuarios_Roles_idRoles = new SelectList(db.roles.Where(item => item.idRoles == 2), "idRoles", "Descripcion");

            
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
            ViewBag.Com_Usuarios_Roles_idRoles = new SelectList(db.roles, "idRoles", "Descripcion", comp_ruta.Com_Usuarios_Roles_idRoles);
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
        public async Task<ActionResult> Edit(comp_ruta comp_ruta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comp_ruta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Verificar = 18;
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


       
        public void Email(int idComp_Bitacora, string Comp_CreadoPor, string nombreTenico, string emailTenico )
        {
            if (ModelState.IsValid)
            {
               
                //string From = (from h in db.com_usuarios
                //             where h.Roles_idRoles.Equals(1)
                //             select h.Com_Correo).SingleOrDefault();

                //string From = "sistemacompuservi@hotmail.com";
                string From = "sistema@compuservi.com.ec";
                //string To = emailTenico + "," + From;
                string To = emailTenico;
                string Subject = "Sistema CONTROL DE VISITAS";
                string Body = "Se creo la ruta #" + idComp_Bitacora + " por el Administrador: " + Comp_CreadoPor + " al tecnico: " + nombreTenico;
                string host, pass;

                //host = "smtp.live.com";
                host = "secure.myhostingdomain.net";
                //pass = "Compuservi2017";
                pass = "Compuservi123";
                MailMessage mail = new MailMessage();
                mail.To.Add(To);
                mail.From = new MailAddress(From);
                mail.Subject = Subject;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("");
                smtp.Host = host;
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(From, pass);
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            else
            {
            }
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
