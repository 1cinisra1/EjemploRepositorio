﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Data.Entity;

namespace WebApplication.Controllers
{
    public class EmpresaController : Controller
    {
        //
        // GET: /Empresa/
        bd_ControlVisitasEntities empresa = new bd_ControlVisitasEntities();
        public ActionResult Index()
        {
            var dato = empresa.cli_empresa;
            return View(dato.ToList());
        }
        public ActionResult CreaEmpresa()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreaEmpresa(cli_empresa val)
        {
            
            if (ModelState.IsValid)
            {
                empresa.cli_empresa.Add(val);
                empresa.SaveChanges();
                return RedirectToAction("Index", "Empresa");
            }
            return RedirectToAction("Index");
        }

        // GET: /cli_Dpto/Edit/5
        public ActionResult ModificaEmpresa(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cli_empresa cli_empresa = empresa.cli_empresa.Find(id);
            if (cli_empresa == null)
            {
                return HttpNotFound();
            }
            return View(cli_empresa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificaEmpresa([Bind(Include = "idCli_Empresa,Cli_Nombre")] cli_empresa Cli_Empresa)
        {
            if (ModelState.IsValid)
            {
                empresa.Entry(Cli_Empresa).State = EntityState.Modified;
                empresa.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Cli_Empresa);
        }
	}
}