using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarProjectUI.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var commentList = _commentService.GetAll();
            return View(commentList);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            _commentService.Add(comment);
            return View();
        }

        public IActionResult ChangeStatus(int id)
        {
            var comment = _commentService.GetById(id);
            if (comment.Status == 1)
            {
                comment.Status = 0;
                _commentService.Update(comment);
            }
            else
            {
                comment.Status = 1;
                _commentService.Update(comment);
            }
            return RedirectToAction("Index","Comment");
        }
    }
}
