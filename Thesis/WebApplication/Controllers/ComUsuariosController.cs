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
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Text;

namespace WebApplication.Controllers
{
    public class comUsuariosController : Controller
    {
        private bd_ControlVisitasEntities db = new bd_ControlVisitasEntities();

        private MySqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
            con = new MySqlConnection(constr);

        } 

        // GET: /comUsuarios/
        public async Task<ActionResult> Index()
        {
            if (Request.IsAuthenticated)
            {
                if (User.IsInRole("1"))
                {
                    ViewBag.Verificar = 18;
            var com_usuarios = db.com_usuarios.Include(c => c.roles);
            return View(await com_usuarios.ToListAsync());
                }
                ViewBag.Verificar = "String";
                return View();
            }
            return RedirectToAction("Login", "MyAccount");
        }

        // GET: /comUsuarios/Details/5
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
            com_usuarios com_usuarios = await db.com_usuarios.FindAsync(id,id1);
            if (com_usuarios == null)
            {
                return HttpNotFound();
            }
            return View(com_usuarios);
            }
            ViewBag.Verificar = "String";
            return View();
            }
             return RedirectToAction("Login", "MyAccount");
        }

        // GET: /comUsuarios/Create
        public ActionResult Create()
        {
             if (Request.IsAuthenticated)
            {
            if (User.IsInRole("1"))
            {
                ViewBag.Verificar = 18;
            ViewBag.Roles_idRoles = new SelectList(db.roles, "idRoles", "Descripcion");
            return View();
            }
            ViewBag.Verificar = "String";
            return View();
            }
             return RedirectToAction("Login", "MyAccount");
        }

        // POST: /comUsuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="idCom_Usuarios,Com_Nombre,Roles_idRoles,Com_Apellido,Com_Correo,Com_Direccion,Com_Cedula,Com_Telefono,Com_Clave")] com_usuarios com_usuarios)
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

        // GET: /comUsuarios/Edit/5
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
                ViewBag.Verificar = 18;
            com_usuarios com_usuarios = await db.com_usuarios.FindAsync(id,id1);
            if (com_usuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.Roles_idRol = new SelectList(db.roles, "idRoles", "Descripcion", com_usuarios.Roles_idRoles);
            return View(com_usuarios);
            }
            ViewBag.Verificar = "String";
            return View();
            }
             return RedirectToAction("Login", "MyAccount");
        }

        // POST: /comUsuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
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

                StringBuilder sentence = new StringBuilder();

                sentence.Append("SET FOREIGN_KEY_CHECKS=0; ");
                sentence.Append("update myapp.com_usuarios ");
                sentence.Append("set Com_Nombre='" + com_usuarios.Com_Nombre + "' ");
                sentence.Append(",Roles_idRoles='" + idrol + "' ");
                sentence.Append(",Com_Apellido='" + com_usuarios.Com_Apellido + "' ");
                sentence.Append(",Com_Correo='" + com_usuarios.Com_Correo + "' ");
                sentence.Append(",Com_Direccion='" + com_usuarios.Com_Direccion + "' ");
                sentence.Append(",Com_Cedula='" + com_usuarios.Com_Cedula + "' ");
                sentence.Append(",Com_Telefono='" + com_usuarios.Com_Telefono + "' ");
                sentence.Append(",Com_Clave='" + com_usuarios.Com_Clave + "' ");
                //condiciones
                sentence.Append("where idCom_Usuarios='" + com_usuarios.idCom_Usuarios + "' ");
                sentence.Append("and Roles_idRoles='" + com_usuarios.Roles_idRoles + "' ");

                sqlComm.CommandText = sentence.ToString();


                con.Open();
                sqlComm.ExecuteNonQuery();
                con.Close();
                return RedirectToAction("Index");
            }
            ViewBag.Roles_idRol = new SelectList(db.roles, "idRoles", "Descripcion", com_usuarios.Roles_idRoles);
            return View(com_usuarios);
        }

        // GET: /comUsuarios/Delete/5
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
                ViewBag.Verificar = 18;
            com_usuarios com_usuarios = await db.com_usuarios.FindAsync(id,id1);
            if (com_usuarios == null)
            {
                return HttpNotFound();
            }
            return View(com_usuarios);
            }
            ViewBag.Verificar = "String";
            return View();
            }
             return RedirectToAction("Login", "MyAccount");
        }

        // POST: /comUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            com_usuarios com_usuarios = await db.com_usuarios.FindAsync(id);
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
