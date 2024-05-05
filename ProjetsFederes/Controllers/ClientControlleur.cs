using Microsoft.AspNetCore.Mvc;
using ProjetsFederes.Models;
using ProjetsFederes.Persistence;

namespace ProjetsFederes.Controllers;

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
            .FirstOrDefault(m => m.Id == id);
        if (client == null)
        {
            return NotFound();
        }

        return View(client);
    }

    // GET: Client/Create
    public IActionResult Create()
    {
        return View(new ClientViewModel());
    }

    // POST: Client/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ClientViewModel model)
    {
        if (ModelState.IsValid)
        {
            var client = new Client(model.Name, model.Email, model.Address, model.SkinType);
            context.Add(client);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        return View(model);
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

        var viewModel = new ClientViewModel
        {
            Id = client.Id,
            Name = client.Name,
            Email = client.Email,
            Address = client.Address,
            SkinType = client.SkinType
        };
        return View(viewModel);
    }

    private bool ClientExists(int id)
    {
        return context.Clients.Any(e => e.Id == id);
    }

    // POST: Client/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, ClientViewModel model)
    {
        if (id != model.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var client = context.Clients.FirstOrDefault(x => x.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            client.Email = model.Email;
            client.Address = model.Address;
            client.SkinType = model.SkinType;

            context.Update(client);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }

    // GET: Client/Delete/5
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var client = context.Clients.FirstOrDefault(m => m.Id == id);
        if (client == null)
        {
            return NotFound();
        }

        context.Clients.Remove(client);
        context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
// POST: Client/Delete/5