﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetsFederes.Models;
using System.Linq;
using ProjetsFederes.Persistence;

namespace ProjetsFederes.Controllers;

public class CategorieController : Controller
{
    private readonly ApplicationContext context;

    public CategorieController(ApplicationContext context)
    {
        this.context = context;
    }

    // GET: Categorie
    public IActionResult Index()
    {
        return View(context.Categories.ToList());
    }

    // GET: Categorie/Details/5
    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var categorie = context.Categories
            .FirstOrDefault(m => m.Id == id);
        if (categorie == null)
        {
            return NotFound();
        }

        return View(categorie);
    }

    // GET: Categorie/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Categorie/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("CategorieId,Nom")] Category category)
    {
        if (ModelState.IsValid)
        {
            context.Add(category);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(category);
    }

    // GET: Categorie/Edit/5
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var categorie = context.Categories.Find(id);
        if (categorie == null)
        {
            return NotFound();
        }
        return View(categorie);
    }

    // POST: Categorie/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("CategorieId,Nom")] Category category)
    {
        if (id != category.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                context.Update(category);
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieExists(category.Id))
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
        return View(category);
    }

    // GET: Categorie/Delete/5
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var categorie = context.Categories
            .FirstOrDefault(m => m.Id == id);
        if (categorie == null)
        {
            return NotFound();
        }

        return View(categorie);
    }

    // POST: Categorie/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var categorie = context.Categories.Find(id);
        if (categorie == null)
        {
            return NotFound();
        }

        context.Categories.Remove(categorie);
        context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    private bool CategorieExists(int id)
    {
        return context.Categories.Any(e => e.Id == id);
    }
}