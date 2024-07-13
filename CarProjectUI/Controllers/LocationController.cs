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

        ICommentService _commentService;

        public LocationController(ICommentService commentService)
        {
            _commentService = commentService;
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
            return RedirectToAction("ArticleDetail", "Article", new {Id=comment.ArticleId});
        }
    }
}
