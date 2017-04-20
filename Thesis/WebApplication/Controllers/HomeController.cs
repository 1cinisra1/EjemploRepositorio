using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult DashboardV1()
        {
            if (Session["LogedUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
        public ActionResult DashboardV2()
        {
            return View();
        }
    }
}