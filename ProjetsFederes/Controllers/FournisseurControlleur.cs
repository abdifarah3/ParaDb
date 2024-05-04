using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetsFederes.Models;
using System.Linq;

namespace ProjetsFederes.Controllers
{
    public class FournisseurController : Controller
    {
        private readonly ApplicationContext context;

        public FournisseurController(ApplicationContext context)
        {
            this.context = context;
        }

        // GET: Fournisseur
        public IActionResult Index()
        {
            return View(this.context.Fournisseurs.ToList());
        }

        // GET: Fournisseur/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fournisseur = this.context.Fournisseurs
                .FirstOrDefault(m => m.FournisseurId == id);
            if (fournisseur == null)
            {
                return NotFound();
            }

            return View(fournisseur);
        }

        // GET: Fournisseur/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fournisseur/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FournisseurId,Nom,Contact")] Fournisseur fournisseur)
        {
            if (ModelState.IsValid)
            {
                this.context.Add(fournisseur);
                this.context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(fournisseur);
        }

        // GET: Fournisseur/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fournisseur = this.context.Fournisseurs.Find(id);
            if (fournisseur == null)
            {
                return NotFound();
            }
            return View(fournisseur);
        }

        // POST: Fournisseur/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("FournisseurId,Nom,Contact")] Fournisseur fournisseur)
        {
            if (id != fournisseur.FournisseurId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.context.Update(fournisseur);
                    this.context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FournisseurExists(fournisseur.FournisseurId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fournisseur);
        }

        // GET: Fournisseur/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fournisseur = this.context.Fournisseurs
                .FirstOrDefault(m => m.FournisseurId == id);
            if (fournisseur == null)
            {
                return NotFound();
            }

            return View(fournisseur);
        }

        // POST: Fournisseur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var fournisseur = this.context.Fournisseurs.Find(id);
            this.context.Fournisseurs.Remove(fournisseur);
            this.context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool FournisseurExists(int id)
        {
            return this.context.Fournisseurs.Any(e => e.FournisseurId == id);
        }
    }
}
