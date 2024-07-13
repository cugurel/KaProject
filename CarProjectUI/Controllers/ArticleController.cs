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
        
        public ArticleController(IArticleService articleService, ICommentService commentService)
        {
            _articleService = articleService;
        }

        public IActionResult Index()
        {
            var article = _articleService.GetAll();
            return View(article);
        }

        public IActionResult ArticleDetail(int id)
        {
            var article = _articleService.GetById(id);
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
        public async Task<IActionResult> UpdateArticle(Article article)
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
                article.UpdatedDate = DateTime.Now;
                article.FileUrl = randomName;
                _articleService.Update(article);
            }

            var value = _articleService.GetById(article.Id);
            if(value.FileUrl == null)
            {
                article.UpdatedDate = DateTime.Now;
                article.FileUrl = null;
                _articleService.Update(article);
            }
            else
            {
                article.UpdatedDate = DateTime.Now;
                article.FileUrl = value.FileUrl;
                _articleService.Update(article);
            }
            
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
