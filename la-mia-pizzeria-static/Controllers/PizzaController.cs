﻿using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using var ctx = new PizzaContext();

            var pizze = ctx.Pizze.ToArray();

            return View(pizze);
        }

        [HttpGet]
        public IActionResult Show(int Id) 
        {
            using var ctx = new PizzaContext();

            var pizze = ctx.Pizze.SingleOrDefault(p => p.Id == Id);

            if (pizze == null)
            {
                return NotFound($"Pizza {Id} non trovata");
            }

            return View(pizze);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza data)
        {

            if (!ModelState.IsValid)
            {
                return View("Create", data);
            }

            using (PizzaContext ctx = new PizzaContext())
            {
                Pizza nuovaPizza = new Pizza();
                nuovaPizza.Name = data.Name;
                nuovaPizza.Description = data.Description;
                nuovaPizza.ImgUrl = data.ImgUrl;

                ctx.Pizze.Add(nuovaPizza);
                ctx.SaveChanges();

                return RedirectToAction("Index");
            }          
        }

    }
}