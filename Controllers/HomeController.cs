using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ng2_kestrel_appserver.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var url = Request.Path.Value;
            if (url.EndsWith(".ico") || url.EndsWith(".map")) {
                return new HttpStatusCodeResult(404);
            } else {
                Redirect("index.html");
            }

            return View();
        }
    }
}
