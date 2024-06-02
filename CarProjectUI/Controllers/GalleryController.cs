using Business.Abstract;
using DataAccess.Concrete.EfRepository;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CarProjectUI.Controllers
{
    public class GalleryController : Controller
    {
        IGalleryService _galleryService;

        public GalleryController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

        public IActionResult Index()
        {
            var galleryList = _galleryService.GetAll();
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
            _galleryService.Add(gallery);
            return RedirectToAction("Index","Gallery");
        }

        [HttpGet]
        public IActionResult UpdateGallery(int id)
        {
            var gallery = _galleryService.GetById(id);
            return View(gallery);
        }

        [HttpPost]
        public IActionResult UpdateGallery(Gallery gallery)
        {
            _galleryService.Update(gallery);
            return RedirectToAction("Index", "Gallery");
        }

        public IActionResult DeleteGallery(int id)
        {
            var gallery = _galleryService.GetById(id);
            _galleryService.Delete(gallery);
            return RedirectToAction("Index", "Gallery");
        }
    }
}
