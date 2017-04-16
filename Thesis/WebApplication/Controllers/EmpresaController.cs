using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Controllers
{
    public class EmpresaController : Controller
    {
        //
        // GET: /Empresa/
        MyappContext.MyappDataContext entidad = new MyappContext.MyappDataContext();
        public ActionResult Index()
        {
            try
            {             
                var dato = entidad.CliEmpresas;
                return View(dato.ToList());
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
                return View();
            }
            
         
            
        }
        public ActionResult CreaEmpresa()
        {
            return RedirectToAction("Index", "Empresa");
        }
        public ActionResult ModificaEmpresa(){
            return View();
        }
	}
}