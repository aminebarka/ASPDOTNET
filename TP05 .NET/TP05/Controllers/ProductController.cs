using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting.Internal;
using sitedeventeTP05.Models;
using sitedeventeTP05.Views.ViewModels;

namespace sitedeventeTP05.Controllers
{
    public class ProductController : Controller
    {
        readonly IRepository<Produit> ProduitRepository;
        readonly CategorieRepository categorieRepository;

        private readonly IWebHostEnvironment hostingEnvironment;
        //injection de dépendance
        public ProductController(IRepository<Produit> prodRepository, IWebHostEnvironment hostingEnvironment, CategorieRepository categorieRepository)
        {
            ProduitRepository = prodRepository;
            this.categorieRepository = categorieRepository;
            this.hostingEnvironment = hostingEnvironment;

        }
        // GET: ProduitController
        public ActionResult Index()
        {
            var produit = ProduitRepository.GetAll();
            return View(produit);
        }

        // GET: ProduitController/Details/5
        public ActionResult Details(int id)
        {
            var produit = ProduitRepository.Get(id);
            return View(produit);
        }

        // GET: ProduitController/Create
        public ActionResult Create()
        {
            ViewBag.CategorieId = new SelectList(categorieRepository.GetAll(), "CategorieId", "Nom");
            return View();
        }

        // POST: ProduitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel model)
        {
            ViewBag.CategorieId = new SelectList(categorieRepository.GetAll(), "CategorieId", "Nom");

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
                Produit newProd = new Produit
                {
                    Nom = model.Nom,
                    Prix = model.Prix,
                    Quantite = model.Quantite,
                    Categorie = model.Categorie,
                    CategorieId = model.CategorieId,
                    // Store the file name in ImagePath property of the product object
                    // which gets saved to the Products database table
                    Image = uniqueFileName
                };

                ProduitRepository.Add(newProd);
                return RedirectToAction("details", new { id = newProd.ProduitId });
            }
            return View();
        }

        // GET: ProduitController/Edit/5
        public ActionResult Edit(int id)
        {
            Produit produit = ProduitRepository.Get(id);
            EditViewModel produitEditViewModel = new EditViewModel
            {
                
                Nom = produit.Nom,
                Prix = produit.Prix,
                Quantite = produit.Quantite,

                ExistingImagePath = produit.Image
            };
            return View(produitEditViewModel);
        }


        // POST: ProduitController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditViewModel model)
        {
            // Check if the provided data is valid, if not rerender the edit view
            // so the user can correct and resubmit the edit form
            if (ModelState.IsValid)
            {
                // Retrieve the produit being edited from the database
                Produit produit = ProduitRepository.Get(model.ProduitId);
                // Update the produit object with the data in the model object
                produit.Nom = model.Nom;
                produit.Prix = model.Prix;
                produit.Quantite = model.Quantite;
                // If the user wants to change the photo, a new photo will be
                // uploaded and the Photo property on the model object receives
                // the uploaded photo. If the Photo property is null, user did
                // not upload a new photo and keeps his existing photo
                if (model.ImagePath != null)
                {
                    // If a new photo is uploaded, the existing photo must be
                    // deleted. So check if there is an existing photo and delete
                    if (model.ExistingImagePath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingImagePath);
                        System.IO.File.Delete(filePath);
                    }
                    // Save the new photo in wwwroot/images folder and update
                    // PhotoPath property of the produit object which will be
                    // eventually saved in the database
                    produit.Image = ProcessUploadedFile(model);
                }
                // Call update method on the repository service passing it the
                // produit object to update the data in the database table
                Produit updatedProduit = ProduitRepository.Update(produit);
                if (updatedProduit != null)
                    return RedirectToAction("Index");
                else
                    return NotFound();
            }
            return View(model);
        }
        [NonAction]
        private string ProcessUploadedFile(EditViewModel model)
        {
            string uniqueFileName = null;
            if (model.ImagePath != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImagePath.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImagePath.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        // GET: ProduitController/Delete/5
        public ActionResult Delete(int id)
        {
            var produit = ProduitRepository.Get(id);
            return View(produit);
        }

        // POST: ProduitController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Produit p)
        {
            try
            {
                ProduitRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}