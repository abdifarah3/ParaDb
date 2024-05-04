using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetsFederes.Models;
using System.Linq;

namespace ProjetsFederes.Controllers
{
    public class CommandeController : Controller
    {
        private readonly ApplicationContext context;

        public CommandeController(ApplicationContext context)
        {
            this.context = context;
        }

        // GET: Commande
        public IActionResult Index()
        {
            return View(context.Commandes.Include(c => c.Client).ToList());
        }

        // GET: Commande/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commande = context.Commandes
                .Include(c => c.Client)
                .FirstOrDefault(m => m.CommandeId == id);

            if (commande == null)
            {
                return NotFound();
            }

            return View(commande);
        }

        // GET: Commande/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Commande/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CommandeId,DateCommande,Statut,ClientId")] Commande commande)
        {
            if (ModelState.IsValid)
            {
                context.Add(commande);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(commande);
        }

        // GET: Commande/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commande = context.Commandes.Find(id);

            if (commande == null)
            {
                return NotFound();
            }
            return View(commande);
        }

        // POST: Commande/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CommandeId,DateCommande,Statut,ClientId")] Commande commande)
        {
            if (id != commande.CommandeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(commande);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommandeExists(commande.CommandeId))
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
            return View(commande);
        }

        // GET: Commande/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commande = context.Commandes
                .Include(c => c.Client)
                .FirstOrDefault(m => m.CommandeId == id);

            if (commande == null)
            {
                return NotFound();
            }

            return View(commande);
        }

        // POST: Commande/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var commande = context.Commandes.Find(id);
            context.Commandes.Remove(commande);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CommandeExists(int id)
        {
            return context.Commandes.Any(e => e.CommandeId == id);
        }
    }
}
