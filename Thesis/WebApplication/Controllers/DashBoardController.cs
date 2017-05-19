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

        //public ActionResult CharterColumn()
        //{
        //    var _context = new bd_ControlVisitasEntities();
        //    ArrayList xValues = new ArrayList();
        //    ArrayList yValues = new ArrayList();

        //    var results = (from c in _context.comp_ruta
        //                   where (c.Comp_Fecha == DateTime.Today)
        //                   select c);


        //    results.ToList().ForEach(rs => xValues.Add(rs.com_usuarios.Com_Nombre));
        //    results.ToList().ForEach(rs => yValues.Add(rs.Comp_estado));

        //    new Chart(width: 700, height: 500, theme: ChartTheme.Green)
        //   .AddTitle("SALIDA DE TECNICOS")
        //   .AddSeries("Default", chartType: "Column", xValue: xValues, yValues: yValues)
        //   .Write("BMP");
           
        //    return null;
        //}

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
