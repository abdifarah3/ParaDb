using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetsFederes.Models;
using System.Linq;

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
            return View(context.DetailCommandes.Include(dc => dc.Produit).Include(dc => dc.Commande).ToList());
        }

        // GET: DetailCommande/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailCommande = context.DetailCommandes
                .Include(dc => dc.Produit)
                .Include(dc => dc.Commande)
                .FirstOrDefault(m => m.DetailCommandeId == id);
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
        public IActionResult Create([Bind("DetailCommandeId,Quantite,PrixUnitaire,ProduitId,CommandeId")] DetailCommande detailCommande)
        {
            if (ModelState.IsValid)
            {
                context.Add(detailCommande);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(detailCommande);
        }

        // GET: DetailCommande/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailCommande = context.DetailCommandes
                .Include(dc => dc.Produit)
                .Include(dc => dc.Commande)
                .FirstOrDefault(m => m.DetailCommandeId == id);
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
            var detailCommande = context.DetailCommandes.Find(id);
            context.DetailCommandes.Remove(detailCommande);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool DetailCommandeExists(int id)
        {
            return context.DetailCommandes.Any(e => e.DetailCommandeId == id);
        }
    }
}
