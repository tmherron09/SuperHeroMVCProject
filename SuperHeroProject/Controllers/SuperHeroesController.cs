using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SuperHeroProject.Data;
using SuperHeroProject.Models;

namespace SuperHeroProject.Controllers
{
    public class SuperHeroesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SuperHeroesController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        // GET: SuperHeroesController
        public ActionResult Index()
        {
            var allSuperHeroes = _context.SuperHeroes.ToList();
            return View(allSuperHeroes);
        }

        // GET: SuperHeroesController/Details/5
        public ActionResult Details(int id)
        {
            var selectedSuperHero = _context.SuperHeroes.Where(s => s.Id == id).FirstOrDefault();
            return View(selectedSuperHero);
        }

        // GET: SuperHeroesController/Create
        public ActionResult Create()
        {
            SuperHero createdHero = new SuperHero();

            return View(createdHero);
        }

        // POST: SuperHeroesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("SuperHeroName,AlterEgo,PrimaryAbility,SecondaryAbility,Catchphrase")]SuperHero createdHero)
        {
            try
            {
                _context.SuperHeroes.Add(createdHero);
                var refSuperHero = _context.Entry(createdHero);
                _context.SaveChanges();

                return View("Details", refSuperHero.Entity);
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroesController/Edit/5
        public ActionResult Edit(int id)
        {
            var hero = _context.SuperHeroes.Where(s => s.Id == id).FirstOrDefault();

            return View(hero);
        }

        // POST: SuperHeroesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("SuperHeroName,AlterEgo,PrimaryAbility,SecondaryAbility,Catchphrase")] SuperHero heroToEdit)
        {
            try
            {
                heroToEdit.Id = id;
                _context.SuperHeroes.Update(heroToEdit);
                _context.SaveChanges();

                return View("Details", heroToEdit);
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroesController/Delete/5
        public ActionResult Delete(int id)
        {
            SuperHero hero = _context.SuperHeroes.Where(s => s.Id == id).FirstOrDefault();
            return View(hero);
        }

        // POST: SuperHeroesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SuperHero hero)
        {
            if(hero == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.SuperHeroes.Remove(hero);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
