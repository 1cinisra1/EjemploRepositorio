using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Repositorio;

namespace WebApplication.Controllers
{
    public class DashBoardController : Controller
    {
        private bd_ControlVisitasEntities db = new bd_ControlVisitasEntities();
        public ActionResult DashboardV1()
        {
            int PorcentajeRealizadas = 0;
            int Pendiente = 0;
            var cantVisitas = db.comp_ruta.Where(e => e.Comp_Fecha == DateTime.Today);
            int cantVisitasDia=cantVisitas.Count();
            ViewBag.cantidad = cantVisitasDia;
            var realizadas = db.comp_ruta.Where(e => e.Comp_Fecha == DateTime.Today && e.Comp_estado);
            int cantRealizadas=realizadas.Count();
            if (cantVisitasDia > 0)
            {
                 PorcentajeRealizadas = (cantRealizadas * 100) / cantVisitasDia;
                 Pendiente = 100;
            }

            ViewBag.porcentaje = PorcentajeRealizadas;
            ViewBag.pending = Pendiente - PorcentajeRealizadas;
            int cantClientes = db.cli_cliente.Count();
            ViewBag.numClientes = cantClientes;
            ViewBag.muchachos = ViewBag.namesUSR;
            return View(cantVisitas.ToList());
        }
        
         ICharts _ICharts;
         public DashBoardController()  
        {  
            _ICharts = new ChartsConcrete();      
        }  
  
        [HttpGet]  
        public ActionResult Index()  
        {  
            try  
            {  
                string temTecnicos = string.Empty;  
                string tempCantidad = string.Empty;  

                _ICharts.ListaTecnicos(out temTecnicos, out tempCantidad);

                string newList = string.Join(",", temTecnicos.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                ViewBag.Tecnicos_List = newList.Trim();  
                ViewBag.Cantidad_List = tempCantidad.Trim();  
  
                return View();  
            }  
            catch (Exception)  
            {              
                throw;  
            }  
        }



    }
}
