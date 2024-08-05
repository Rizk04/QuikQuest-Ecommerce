using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuikQuest.Areas.Identity.Data;
using QuikQuest.Data;
using QuikQuest.Models;
using System.Security.Claims;

namespace QuikQuest.Controllers
{
    [Authorize]
    public class FeedbackController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<QuikQuestUser> _userManager;
        public FeedbackController(AppDbContext db, UserManager<QuikQuestUser> usermanager)
        {
            _db = db;
            _userManager = usermanager;

        }

        
        [HttpGet]
        public IActionResult AddReview()
        {
            return View();
        }
        [HttpPost]

        public IActionResult AddReview(Review review)
        {
            if (review == null)
            {
                return NotFound();
            }
            review.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _db.Reviews.Add(review);
            _db.SaveChanges();
            return  RedirectToAction("Index", "Home");

        }


        [HttpGet]
        public IActionResult AddQuestion()
        {
            return View();
        }
        [HttpPost]

        public IActionResult AddQuestion(Question question)
        {
            if (question == null)
            {
                return NotFound();
            }
            question.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _db.Questions.Add(question);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");

        }



    }
}
