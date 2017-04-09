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

            EmpresaAccount e2 = new EmpresaAccount();
            e2.codigo = 2;
            e2.nombre = "Machinetech";
            e2.direccion = "Ceibos";
            e2.ciudad = "Guayaquil";
            e2.telefono = "042627748";
            e2.ruc = "0999999999";
            lista.Add(e2);

            EmpresaAccount e3 = new EmpresaAccount();
            e3.codigo = 3;
            e3.nombre = "PSI";
            e3.direccion = "Kennedy";
            e3.ciudad = "Guayaquil";
            e3.telefono = "042627748";
            e3.ruc = "0999999999";
            lista.Add(e3);

            EmpresaAccount e4 = new EmpresaAccount();
            e4.codigo = 4;
            e4.nombre = "PSI";
            e4.direccion = "Kennedy";
            e4.ciudad = "Guayaquil";
            e4.telefono = "042627748";
            e4.ruc = "0999999999";
            lista.Add(e4);

            EmpresaAccount e5 = new EmpresaAccount();
            e5.codigo = 5;
            e5.nombre = "PSI";
            e5.direccion = "Kennedy";
            e5.ciudad = "Guayaquil";
            e5.telefono = "042627748";
            e5.ruc = "0999999999";
            lista.Add(e5);

            EmpresaAccount e6 = new EmpresaAccount();
            e6.codigo = 6;
            e6.nombre = "PSI";
            e6.direccion = "Kennedy";
            e6.ciudad = "Guayaquil";
            e6.telefono = "042627748";
            e6.ruc = "0999999999";
            lista.Add(e6);

            EmpresaAccount e7 = new EmpresaAccount();
            e7.codigo = 7;
            e7.nombre = "PSI";
            e7.direccion = "Kennedy";
            e7.ciudad = "Guayaquil";
            e7.telefono = "042627748";
            e7.ruc = "0999999999";
            lista.Add(e7);

            EmpresaAccount e8 = new EmpresaAccount();
            e8.codigo = 8;
            e8.nombre = "PSI";
            e8.direccion = "Kennedy";
            e8.ciudad = "Guayaquil";
            e8.telefono = "042627748";
            e8.ruc = "0999999999";
            lista.Add(e8);

            EmpresaAccount e9 = new EmpresaAccount();
            e9.codigo = 9;
            e9.nombre = "PSI";
            e9.direccion = "Kennedy";
            e9.ciudad = "Guayaquil";
            e9.telefono = "042627748";
            e9.ruc = "0999999999";
            lista.Add(e9);

            EmpresaAccount e10 = new EmpresaAccount();
            e10.codigo = 10;
            e10.nombre = "PSI";
            e10.direccion = "Kennedy";
            e10.ciudad = "Guayaquil";
            e10.telefono = "042627748";
            e10.ruc = "0999999999";
            lista.Add(e10);

            return View(lista);
        }
        public ActionResult CreaEmpresa()
        {
            return View();
        }
	}
}