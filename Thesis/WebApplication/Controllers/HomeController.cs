using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
       
    
        [AllowAnonymous]
        public ActionResult Index()
        {

            return View();
        }
        [Authorize]
        public ActionResult MyProfile()
        {

            return View();
        }





    }
}