using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetsFederes.Models;
using System.Linq;
using ProjetsFederes.Persistence;

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
            return View(context.Orders.Include(c => c.Client).ToList());
        }

        // GET: Commande/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commande = context.Orders
                .Include(c => c.Client)
                .FirstOrDefault(m => m.Id == id);

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
        public IActionResult Create([Bind("CommandeId,DateCommande,Statut,ClientId")] Order order)
        {
            if (ModelState.IsValid)
            {
                context.Add(order);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Commande/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commande = context.Orders.Find(id);

            if (commande == null)
            {
                return NotFound();
            }
            return View(commande);
        }

        // POST: Commande/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CommandeId,DateCommande,Statut,ClientId")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(order);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommandeExists(order.Id))
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
            return View(order);
        }

        // GET: Commande/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commande = context.Orders
                .Include(c => c.Client)
                .FirstOrDefault(m => m.Id == id);

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
            var commande = context.Orders.Find(id);
            context.Orders.Remove(commande);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CommandeExists(int id)
        {
            return context.Orders.Any(e => e.Id == id);
        }
    }
}
