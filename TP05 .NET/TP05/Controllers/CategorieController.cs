﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sitedeventeTP05.Models;

namespace sitedeventeTP05.Controllers
{
    public class CategorieController : Controller
    {
        readonly IRepository1<Categorie> CategorieRepository;
        public CategorieController(IRepository1<Categorie> CategorieRepository)
        {
            this.CategorieRepository = CategorieRepository;
        }
        // GET: CategorieController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CategorieController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategorieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategorieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CategorieController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategorieController/Edit/5
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

        // GET: CategorieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategorieController/Delete/5
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
