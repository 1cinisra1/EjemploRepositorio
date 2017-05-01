using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class MyAccountController : Controller
    {
        private bd_ControlVisitasEntities db = new bd_ControlVisitasEntities();
        
        //
        // GET: /MyAccount/
        public ActionResult Login()
        {
            Session.Clear();
           
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(com_usuarios l, string returnURL = "")
        {
            #region vieja_forma
            //var user = db.com_usuarios.Where(a => a.Com_Correo.Equals(l.Com_Correo) && a.Com_Clave.Equals(l.Com_Clave)).FirstOrDefault();
            //if (user != null)
            //{
            //    FormsAuthentication.SetAuthCookie(user.Com_Correo, true);
            //    if (Url.IsLocalUrl(returnURL))
            //    {
            //        return Redirect(returnURL);
            //    }
            //    else
            //    {
            //        return RedirectToAction("Index", "CompRuta");

            //    }

            //}
            #endregion 

            if (ModelState.IsValid)
            {
                var isValidUser = Membership.ValidateUser(l.Com_Correo, l.Com_Clave);
                if (isValidUser)
                {
                    FormsAuthentication.SetAuthCookie(l.Com_Correo, true);
                    if (Url.IsLocalUrl(returnURL))
                    {
                        return Redirect(returnURL);
                    }
                    else
                    {
                        return RedirectToAction("Index", "CompRuta");
                    }
                }
            }          
            ModelState.Remove("Com_Clave");
            return View();
        }





        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }


        //
        // GET: /MyAccount/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /MyAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MyAccount/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /MyAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /MyAccount/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /MyAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /MyAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
