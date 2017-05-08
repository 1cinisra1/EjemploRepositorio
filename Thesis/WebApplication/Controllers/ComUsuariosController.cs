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
using System.Data.Entity.Core;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Text;


namespace WebApplication.Controllers
{
    public class ComUsuariosController : Controller
    {
        private bd_ControlVisitasEntities db = new bd_ControlVisitasEntities();
       
        private MySqlConnection con;
       
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
            con = new MySqlConnection(constr);

        } 


        // GET: /ComUsuarios/
         
        public async Task<ActionResult> Index()
        {
            var com_usuarios = db.com_usuarios.Include(c => c.roles);
            return View(await com_usuarios.ToListAsync());
        }

        // GET: /ComUsuarios/Details/5
        public async Task<ActionResult> Details(int? id,int? id1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            com_usuarios com_usuarios = await db.com_usuarios.FindAsync(id,id1);
            if (com_usuarios == null)
            {
                return HttpNotFound();
            }
            return View(com_usuarios);
        }

        // GET: /ComUsuarios/Create
        public ActionResult Create()
        {
            ViewBag.Roles_idRoles = new SelectList(db.roles, "idRoles", "Descripcion");
            return View();
        }

        // POST: /ComUsuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(com_usuarios com_usuarios)
        {
            if (ModelState.IsValid)
            {
                db.com_usuarios.Add(com_usuarios);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Roles_idRoles = new SelectList(db.roles, "idRoles", "Descripcion", com_usuarios.Roles_idRoles);
            return View(com_usuarios);
        }

        // GET: /ComUsuarios/Edit/5
        public async Task<ActionResult> Edit(int? id,int? id1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            com_usuarios com_usuarios = await db.com_usuarios.FindAsync(id,id1);
            if (com_usuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.Roles_idRol = new SelectList(db.roles, "idRoles", "Descripcion", com_usuarios.Roles_idRoles);
            return View(com_usuarios);
        }

        // POST: /ComUsuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit(com_usuarios com_usuarios)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var idrol = com_usuarios.Roles_idRoles;
        //        ModelState.Remove("Roles_idRoles");
        //        db.Entry(com_usuarios).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Roles_idRoles = new SelectList(db.roles, "idRoles", "Descripcion", com_usuarios.Roles_idRoles);
        //    return View(com_usuarios);
        //}




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(com_usuarios com_usuarios, FormCollection form)
        {
            if (ModelState.IsValid)
            {

                connection();
                MySqlCommand sqlComm = new MySqlCommand();
                int idrol = Convert.ToInt32(form["Roles_idRol"]);
                sqlComm = con.CreateCommand();

                StringBuilder sentences = new StringBuilder();
                
                sentences.Append("SET FOREIGN_KEY_CHECKS=0; ");
                sentences.Append("update myapp.com_usuarios ");
                sentences.Append("set Com_Nombre='" + com_usuarios.Com_Nombre + "' ");
                sentences.Append(",Roles_idRoles='" + idrol + "' ");
                sentences.Append(",Com_Apellido='" + com_usuarios.Com_Apellido + "' ");
                sentences.Append(",Com_Correo='" + com_usuarios.Com_Correo + "' ");
                sentences.Append(",Com_Direccion='" + com_usuarios.Com_Direccion + "' ");
                sentences.Append(",Com_Cedula='" + com_usuarios.Com_Cedula + "' ");
                sentences.Append(",Com_Telefono='" + com_usuarios.Com_Telefono + "' ");
                sentences.Append(",Com_Clave='" + com_usuarios.Com_Clave + "' ");
                //condiciones
                sentences.Append("where idCom_Usuarios='" + com_usuarios.idCom_Usuarios + "' ");
                sentences.Append("and Roles_idRoles='" + com_usuarios.Roles_idRoles + "' ");

                sqlComm.CommandText = sentences.ToString();


                con.Open();
                sqlComm.ExecuteNonQuery();
                con.Close();

                return RedirectToAction("Index");
                
               
           }
                

          
            ViewBag.Roles_idRol = new SelectList(db.roles, "idRoles", "Descripcion", com_usuarios.Roles_idRoles);
            return View(com_usuarios);

            
        }

        // GET: /ComUsuarios/Delete/5
        public async Task<ActionResult> Delete(int? id,int? id1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            com_usuarios com_usuarios = await db.com_usuarios.FindAsync(id,id1);
            if (com_usuarios == null)
            {
                return HttpNotFound();
            }
            return View(com_usuarios);
        }

        // POST: /ComUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id,int id1)
        {
            com_usuarios com_usuarios = await db.com_usuarios.FindAsync(id,id1);
            db.com_usuarios.Remove(com_usuarios);
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
