using ExemploMVC.Models;
using ExemploMVC.Models.Data;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ExemploMVC.Controllers
{
    public class EnderecosController : Controller
    {
        private DataContext db = new DataContext();

        public ActionResult Novo(int u)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Novo(Endereco endereco, int u)
        {
            if (u == default(int))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (ModelState.IsValid)
            {
                endereco.MoradorId = u;
                db.Enderecos.Add(endereco);
                await db.SaveChangesAsync();
                return RedirectToAction("Detalhes", "Usuarios", new { id = u });
            }

            return View(endereco);
        }

        public async Task<ActionResult> Deletar(int? id, int u)
        {
            if (id == null || u == default(int))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = await db.Enderecos.FindAsync(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: Enderecoes/Delete/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ConfirmacaoDeletar(int id, int u)
        {
            if (u == default(int))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Endereco endereco = await db.Enderecos.FindAsync(id);
            db.Enderecos.Remove(endereco);
            await db.SaveChangesAsync();
            return RedirectToAction("Detalhes", "Usuarios", new { id = u });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
