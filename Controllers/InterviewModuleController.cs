using Microsoft.AspNetCore.Mvc;
using SEP_App.Models;

namespace SEP_App.Controllers
{
    public class InterviewModuleController : Controller
    {
        private readonly InterviewOnlineTestService _IOTS;
        public InterviewModuleController(InterviewOnlineTestService IOTS)
        {
            this._IOTS = IOTS;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAllQuestions()
        {
            var questions = _IOTS.GetAllQuestions();
            
             return View(questions);

        }
         
        [HttpPost]
         public IActionResult TestSubmission(IFormCollection form)
         {
            int score = 0;

            foreach (var key in form.Keys)
            {
                if (int.TryParse(form[key], out int selectedOption))
                {
                    int questionId = int.Parse(key.Replace("question", ""));

                    var question = _IOTS.GetAllQuestions().FirstOrDefault(q=>q.Qno ==questionId);
                    if (selectedOption==question?.answer)
                    {
                        score++;
                    }
                }
            }

            ViewData["score"] = score;
            TempData["score"] = score;
            
            return View();
             
         }


        [HttpPost]
        public IActionResult ScoreSubmission()
        {
            _IOTS.Scoresubmission(TempData);

            return RedirectToAction("CandidateSignIn", "PreSEP");
        }

        [HttpGet]
        public IActionResult GetScore()
        {
          var candetails = _IOTS.GetTestScore();
          return View(candetails);
        }

        [HttpGet]
        public IActionResult GetInstructions()
        {
            return View();
        }

    }
}
