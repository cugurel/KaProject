using Business.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace CarProjectUI.Controllers
{
    public class LocationController : Controller
    {

        Context c = new Context();

        IArticleService _articleService;
        ICommentService _commentService;

        public LocationController(IArticleService articleService, ICommentService commentService)
        {
            _articleService = articleService;
            _commentService = commentService;
        }
        public IActionResult LocationDetail(int id)
        {
            ViewBag.Comments = _commentService.GetAll().Where(x => x.ArticleId == id && x.Status == 1).ToList();
            var article = _articleService.GetById(id);
            return View(article);
        }
        public IActionResult Index(int page = 1)
        {
            var locations = c.Articles.ToList().ToPagedList(page, 2); ;
            return View(locations);
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            _commentService.Add(comment);
            return RedirectToAction("LocationDetail", "Location", new {Id=comment.ArticleId});
        }
    }
}
