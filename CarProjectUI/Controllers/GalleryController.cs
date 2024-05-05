using DataAccess.Concrete.EfRepository;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CarProjectUI.Controllers
{
    public class GalleryController : Controller
    {
        EfGalleryRepository efGalleryRepository = new EfGalleryRepository();
        public IActionResult Index()
        {
            var galleryList = efGalleryRepository.GetAll();
            return View(galleryList);
        }

        [HttpGet]
        public IActionResult AddGallery()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGallery(Gallery gallery)
        {
            efGalleryRepository.Add(gallery);
            return RedirectToAction("Index","Gallery");
        }

        [HttpGet]
        public IActionResult UpdateGallery(int id)
        {
            var gallery = efGalleryRepository.GetById(id);
            return View(gallery);
        }

        [HttpPost]
        public IActionResult UpdateGallery(Gallery gallery)
        {
            efGalleryRepository.Add(gallery);
            return RedirectToAction("Index", "Gallery");
        }
    }
}
