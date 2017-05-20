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
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace WebApplication.Controllers
{
    public class CompRutaTecnicoController : Controller
    {
        private bd_ControlVisitasEntities db = new bd_ControlVisitasEntities();

        // GET: /compRuta/
        public async Task<ActionResult> Index()
        {
            if (Request.IsAuthenticated)
            {
                var comp_ruta = db.comp_ruta.Include(c => c.cli_user).Include(c => c.com_usuarios);
                return View(await comp_ruta.ToListAsync());
               
              
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
                
                    comp_ruta comp_ruta = await db.comp_ruta.FindAsync(id);
                    if (comp_ruta == null)
                    {
                        return HttpNotFound();
                    }
                    return View(comp_ruta);
               
            }
            return RedirectToAction("Login", "MyAccount");
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
                  comp_ruta comp_ruta = await db.comp_ruta.FindAsync(id);
                    if (comp_ruta == null)
                    {
                        return HttpNotFound();
                    }
                    ViewBag.Cli_Usuario_idCli_Usuario = new SelectList(db.cli_user, "idCli_Usuario", "Cli_nombre", comp_ruta.Cli_Usuario_idCli_Usuario);
                    ViewBag.Com_Usuarios_idCom_Usuarios = new SelectList(db.com_usuarios, "idCom_Usuarios", "Com_Nombre", comp_ruta.Com_Usuarios_idCom_Usuarios);
                    ViewBag.Com_Usuarios_Roles_idRoles = new SelectList(db.roles, "idRoles", "Descripcion");
                    return View(comp_ruta);
              
            }
            return RedirectToAction("Login", "MyAccount");
        }

        // POST: /compRuta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idComp_Bitacora,Comp_Fecha,Comp_NumeroVisitaMes,Comp_TiempoDur,Comp_Comentario,Comp_estado,Comp_HoraLlegada,Comp_HoraSalida,Comp_CreadoPor,Comp_CerradoPor,Com_Usuarios_idCom_Usuarios,Cli_Usuario_idCli_Usuario,Com_Usuarios_Roles_idRoles")] comp_ruta comp_ruta)
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



        [HttpGet]
        public ActionResult Export(int id)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports/CrystalReportRuta.rpt")));

            var query = (from p in db.comp_ruta
                        where p.idComp_Bitacora == id
                        select new 
                        {
                            Comp_Fecha = p.Comp_Fecha,
                            Comp_estado = p.Comp_estado,
                            Com_Usuarios_idCom_Usuarios = p.com_usuarios.Com_Nombre,
                            Cli_Usuario_idCli_Usuario = p.cli_user.Cli_nombre,
                            Comp_HoraLlegada = p.Comp_HoraLlegada,
                            Comp_HoraSalida = p.Comp_HoraSalida,
                            Comp_Comentario = p.Comp_Comentario,
                            Comp_CreadoPor = p.Comp_CreadoPor,
                            Comp_CerradoPor = p.Comp_CerradoPor
                        }).ToList();

            rd.SetDataSource(query);
            //rd.SetDataSource(db.comp_ruta.Where(x => x.idComp_Bitacora == id).ToList());

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream st = rd.ExportToStream
                (CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            st.Seek(0, SeekOrigin.Begin);
            return File(st, "application/pdf", "ReporteTrabajo.pdf");

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
