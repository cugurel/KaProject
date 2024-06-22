using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //HttpGet -->Veri çekme
        //HttpPost --> Veri kaydetme
        //HttpPut --> Güncelleme
        //HttpDelete --> Verileri id ile silmemize yarıyor.



        /// <summary>
        /// Tüm kategorileri listeler.
        /// </summary>
        [HttpGet("GetAllCategories")]
        //[ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GetAll()
        {
            var values = _categoryService.GetAll();
            return Ok(values);
        }

        /// <summary>
        /// Girilen id ye göre kategori bilgisi getirir
        /// </summary>
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var value = _categoryService.GetById(id);
            return Ok(value);
        }

        /// <summary>
        /// Yeni kategori ekle
        /// </summary>
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            _categoryService.Add(category);
            return Ok(category);
        }

        /// <summary>
        /// Girilen id ye göre kategori siler
        /// </summary>
        [HttpDelete("DeleteById/{id}")]
        public IActionResult DeleteByID(int id)
        {
            var value = _categoryService.GetById(id);
            _categoryService.Delete(value);
            return Ok(value);
        }

        /// <summary>
        /// Kategori bilgilerini günceller
        /// </summary>
        [HttpPut("UpdateCategory")]
        public IActionResult UpdateCategory(Category categoy)
        {
            _categoryService.Update(categoy);
            return Ok(categoy);
        }
    }
}