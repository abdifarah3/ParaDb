using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetsFederes.Models;
using System.Linq;
using ProjetsFederes.Persistence;

namespace ProjetsFederes.Controllers
{
    public class DetailCommandeController : Controller
    {
        private readonly ApplicationContext context;

        public DetailCommandeController(ApplicationContext context)
        {
            this.context = context;
        }

        // GET: DetailCommande
        public IActionResult Index()
        {
            return View(context.OrderLines.Include(dc => dc.Product).Include(dc => dc.Order).ToList());
        }

        // GET: DetailCommande/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailCommande = context.OrderLines
                .Include(dc => dc.Product)
                .Include(dc => dc.Order)
                .FirstOrDefault(m => m.Id == id);
            if (detailCommande == null)
            {
                return NotFound();
            }

            return View(detailCommande);
        }

        // GET: DetailCommande/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DetailCommande/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("DetailCommandeId,Quantite,PrixUnitaire,ProduitId,CommandeId")] OrderLine orderLine)
        {
            if (ModelState.IsValid)
            {
                context.Add(orderLine);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(orderLine);
        }

        // GET: DetailCommande/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailCommande = context.OrderLines
                .Include(dc => dc.Product)
                .Include(dc => dc.Order)
                .FirstOrDefault(m => m.Id == id);
            if (detailCommande == null)
            {
                return NotFound();
            }

            return View(detailCommande);
        }

        // POST: DetailCommande/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var detailCommande = context.OrderLines.Find(id);
            context.OrderLines.Remove(detailCommande);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool DetailCommandeExists(int id)
        {
            return context.OrderLines.Any(e => e.Id == id);
        }
    }
}
