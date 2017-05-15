using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class DashBoardController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CharterColumn()
        {
            var _context = new bd_ControlVisitasEntities();
            ArrayList xValues = new ArrayList();
            ArrayList yValues = new ArrayList();

            var results = (from c in _context.comp_ruta
                           where (c.Comp_Fecha == DateTime.Today)
                           select c);
                


            results.ToList().ForEach(rs => xValues.Add(rs.com_usuarios.Com_Nombre));
            results.ToList().ForEach(rs => yValues.Add(rs.Comp_HoraSalida));

            new Chart(width: 1000, height: 500, theme: ChartTheme.Green)
            .AddTitle("SALIDA DE TECNICOS")
            .AddSeries("Default", chartType: "Column", axisLabel: "Horas", xValue: xValues, yValues: yValues)
            .Write("BMP");

            return null;
        }
    }
}
