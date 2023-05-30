using GestiondeLocation.Models;
using GestiondeLocation.Models.Repositories;
using GestiondeLocation.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestiondeLocation.Controllers
{

    public class VoitureController : Controller
    {
        readonly SqlVoitureRepository voitureRepository;
        readonly SqlLocationRepository locationRepository;
        private readonly IWebHostEnvironment hostingEnvironment;
        // GET: VoitureController
        public ActionResult Index()
        {
            var Voitures = VoitureRepository.GetAll();
            return View(Voitures);

        }

        // GET: VoitureController/Details/5
        public ActionResult Details(int id)
        {
            var Voitures = VoitureRepository.FindByID(id);
            return View(Voitures);

        }

        // GET: VoitureController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VoitureController/Create
       
        //injection de dépendance
        readonly IRepository<Voiture> VoitureRepository;
       
        public VoitureController(IRepository<Voiture> voitureRepository, IWebHostEnvironment hostingEnvironment)
        {
            VoitureRepository = voitureRepository;
            this.hostingEnvironment = hostingEnvironment;
        }
         // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                // If the Photo property on the incoming model object is not null, then the user has selected an image to upload.
                if (model.ImagePath != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    // To make sure the file name is unique we are appending a new
                    // GUID value and an underscore to the file name
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImagePath.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    model.ImagePath.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Voiture newVoiture = new Voiture
                {
                    Matricule = model.Matricule,
                    Marque = model.Marque,
                    Modele= model.Modele,
                   
              
                    // Store the file name in PhotoPath property of the employee object
                    // which gets saved to the Employees database table
                    Image = uniqueFileName
                };
                VoitureRepository.Add(newVoiture);
                return RedirectToAction("details", new { id = newVoiture.Id });
            }
            return View();
        }


        // GET: VoitureController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VoitureController/Edit/5
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

        // GET: VoitureController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VoitureController/Delete/5
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
