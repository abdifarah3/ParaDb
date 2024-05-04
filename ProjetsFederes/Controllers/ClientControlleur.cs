using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetsFederes.Models;
using System.Linq;

namespace ProjetsFederes.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationContext context;

        public ClientController(ApplicationContext context)
        {
            this.context = context;
        }

        // GET: Client
        public IActionResult Index()
        {
            return View(context.Clients.ToList());
        }

        // GET: Client/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = context.Clients
                .FirstOrDefault(m => m.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Client/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ClientId,Nom,TypePeau,Adresse,Email,DateNaissance")] Client client)
        {
            if (ModelState.IsValid)
            {
                context.Add(client);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Client/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = context.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }
        private bool ClientExists(int id)
        {
            return context.Clients.Any(e => e.ClientId == id);
        }

        // POST: Client/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ClientId,Nom,TypePeau,Adresse,Email,DateNaissance")] Client client)
        {
            if (id != client.ClientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(client);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.ClientId))
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
            return View(client);
        }

        // GET: Client/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = context.Clients
                .FirstOrDefault(m => m.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }
    }
    // POST: Client/Delete/5
}

