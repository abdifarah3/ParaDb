using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetsFederes.Models;
using ProjetsFederes.Persistence;

namespace ProjetsFederes.Controllers;

public class FournisseurController : Controller
{
    private readonly ApplicationContext _context;

    public FournisseurController(ApplicationContext context)
    {
        this._context = context;
    }

    // GET: Fournisseur
    public IActionResult Index()
    {
        return View(this._context.Suppliers.ToList());
    }

    // GET: Fournisseur/Details/5
    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var supplier = this._context.Suppliers.FirstOrDefault(m => m.Id == id);
            
        if (supplier == null)
        {
            return NotFound();
        }

        return View(supplier);
    }

    // GET: Fournisseur/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Fournisseur/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("FournisseurId,Nom,Contact")] Supplier supplier)
    {
        if (ModelState.IsValid)
        {
            this._context.Add(supplier);
            this._context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(supplier);
    }

    // GET: Fournisseur/Edit/5
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var supplier = this._context.Suppliers.Find(id);
        
        if (supplier == null)
        {
            return NotFound();
        }
        return View(supplier);
    }

    // POST: Fournisseur/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("FournisseurId,Nom,Contact")] Supplier supplier)
    {
        if (id != supplier.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                this._context.Update(supplier);
                this._context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(supplier.Id))
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
        return View(supplier);
    }

    // GET: Fournisseur/Delete/5
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var supplier = this._context.Suppliers.FirstOrDefault(m => m.Id == id);
        if (supplier == null)
        {
            return NotFound();
        }

        return View(supplier);
    }

    // POST: Fournisseur/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var supplier = _context.Suppliers.Find(id);
        
        _context.Suppliers.Remove(supplier);
        _context.SaveChanges();
        
        return RedirectToAction(nameof(Index));
    }

    private bool SupplierExists(int id)
    {
        return _context.Suppliers.Any(e => e.Id == id);
    }
}