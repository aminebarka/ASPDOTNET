using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sitedeventeTP05.Models;

namespace sitedeventeTP05.Controllers
{
    public class CommandeController : Controller
    {
        readonly IRepository2<Commande> CommandeRepository;
        public CommandeController(IRepository2<Commande> CommandeRepository)
        {
            this.CommandeRepository = CommandeRepository;
        }
        // GET: CommandeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CommandeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CommandeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommandeController/Create
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

        // GET: CommandeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CommandeController/Edit/5
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

        // GET: CommandeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CommandeController/Delete/5
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
