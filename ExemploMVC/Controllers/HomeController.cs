using ExemploMVC.Models.Data;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ExemploMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext db;

        public HomeController()
        {
            this.db = new DataContext();
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await db.Usuarios.ToListAsync());
        }
    }
}