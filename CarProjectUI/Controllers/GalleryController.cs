using DataAccess.Concrete.EfRepository;
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
    }
}
