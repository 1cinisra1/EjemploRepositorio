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
        public ActionResult Index()
        {
            List<EmpresaAccount> lista = new List<EmpresaAccount>();
            EmpresaAccount e1 = new EmpresaAccount();
            e1.codigo = 1;
            e1.nombre = "Motorline";
            e1.direccion = "Atarazana";
            e1.ciudad = "Guayaquil";
            e1.telefono = "042627748";
            e1.ruc = "0999999999";
            lista.Add(e1);

            List<EmpresaAccount> lista1 = new List<EmpresaAccount>();
            EmpresaAccount e2 = new EmpresaAccount();
            e2.codigo = 2;
            e2.nombre = "Machinetech";
            e2.direccion = "Ceibos";
            e2.ciudad = "Guayaquil";
            e2.telefono = "042627748";
            e2.ruc = "0999999999";
            lista.Add(e2);

            List<EmpresaAccount> lista2 = new List<EmpresaAccount>();
            EmpresaAccount e3 = new EmpresaAccount();
            e3.codigo = 3;
            e3.nombre = "PSI";
            e3.direccion = "Kennedy";
            e3.ciudad = "Guayaquil";
            e3.telefono = "042627748";
            e3.ruc = "0999999999";
            lista.Add(e3);

            return View(lista);
        }
        public ActionResult CreaEmpresa()
        {
            return View();
        }
	}
}