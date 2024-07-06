using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarProjectUI.Controllers
{
    [Authorize]
    public class ArticleController : Controller
    {
        IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult Index()
        {
            var article = _articleService.GetAll();
            return View(article);
        }

        [HttpGet]
        public IActionResult AddArticle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddArticle(Article article)
        {
            if (article.File != null)
            {
                var item = article.File;
                var extend = Path.GetExtension(item.FileName);
                var randomName = ($"{Guid.NewGuid()}{extend}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\ArticleImages", randomName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await item.CopyToAsync(stream);
                }

                article.FileUrl = randomName;
                _articleService.Add(article);
                return Redirect("Index");
            }
            _articleService.Add(article);
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult UpdateArticle(int id)
        {
            var article = _articleService.GetById(id);
            return View(article);
        }

        [HttpPost]
        public IActionResult UpdateArticle(Article article)
        {
            _articleService.Update(article);
            return Redirect("Index");
        }

        public IActionResult DeleteArticle(int id)
        {
            var article = _articleService.GetById(id);
            _articleService.Delete(article);
            return RedirectToAction("Index","Article");
        }
    }
}
