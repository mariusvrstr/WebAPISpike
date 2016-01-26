
namespace Spike.Web.Controllers
{
    using System.Web.Mvc;
    using Models;

    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(new BaseModel());
        }
    }
}