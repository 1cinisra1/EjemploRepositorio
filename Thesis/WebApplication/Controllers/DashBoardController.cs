using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public JsonResult GetSalesData()
        {
            List<comp_ruta> sd = new List<comp_ruta>();
            using (bd_ControlVisitasEntities dc = new bd_ControlVisitasEntities())
            {
                sd = dc.comp_ruta.OrderBy(a => a.com_usuarios).ToList();
            }

            var chartData = new object[sd.Count + 1];
            chartData[0] = new object[]{
                    "Cli_Usuario_idCli_Usuario",
                    "Comp_NumeroVisitaMes",
                    "Com_Usuarios_idCom_Usuarios",
                    "Comp_estado"
                };
            int j = 0;
            foreach (var i in sd)
            {
                j++;
                chartData[j] = new object[] { i.Cli_Usuario_idCli_Usuario, i.Comp_NumeroVisitaMes, i.Com_Usuarios_idCom_Usuarios, i.Comp_estado };
            }

            return new JsonResult { Data = chartData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        
    }
}
