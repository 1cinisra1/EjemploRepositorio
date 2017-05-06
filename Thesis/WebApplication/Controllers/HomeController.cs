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



        [Authorize(Roles="admin")]
        public ActionResult AdminIndex()
        {

            return View();
        }

        [Authorize(Roles = "tecnico")]
        public ActionResult UserIndex()
        {
            return View();
        }


    }
}