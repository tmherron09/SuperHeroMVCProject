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
            List<SuperHero> allSuperHeroes = _context.SuperHeroes.ToList();
            return View(allSuperHeroes);
        }

        // GET: SuperHeroesController/Details/5
        public ActionResult Details(int id)
        {
            SuperHero selectedSuperHero = _context.SuperHeroes.Where(s => s.Id == id).FirstOrDefault();
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
        public ActionResult Create(SuperHero createdHero)
        {
            try
            {


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SuperHeroesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SuperHeroesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
