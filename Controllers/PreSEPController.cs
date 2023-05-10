using Microsoft.AspNetCore.Mvc;
using SEP_App.Models;

namespace SEP_App.Controllers
{
    public class PreSEPController : Controller
    {
        private readonly CandidateService _candidateservice;
        public PreSEPController(CandidateService candidateservice )
        {
            this._candidateservice = candidateservice;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CandidateInformation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CandidateInformation(CandidateDetails cd)
        {
          
                string msg = _candidateservice.CandidateInformation(cd);
                ViewBag.Message = msg;
                return View();
        }

        public IActionResult RegisteredCandidates()
        {
            return View();
        }
       [HttpGet]
       public IActionResult CandidateSignIn()
       {
            return View();
         
       }

        [HttpPost]
        public IActionResult CandidateSignIn(CandidateDetails cd)
        {
            var login = _candidateservice.SignIn(cd);
            int id = login.CandidateId;
            TempData["id"] = id;
            if (login != null)
            {
                
                return RedirectToAction("GetInstructions", "InterviewModule");

            }
           
            
            ViewBag.Message = "Invalid Credentials";
            return View();
        }

        [HttpGet]
        public IActionResult AddCandidate()
        {
            return View();

        }

        [HttpPost]
        public IActionResult AddCandidate(AddCandidate ad, IFormFile file, IFormFile image)
        {

            if (file == null || file.Length == 0)
            {
               
                ViewBag.Message = "Please select a file to upload";
            }
            else
            {
                _candidateservice.AddCandidates(ad, file, image);

                ViewBag.Message = "Candidate details Uploaded Successfully";
            }
            
            return View();
        }

        [HttpGet]
        public IActionResult ViewCandidates()
        {
          var CandidateList = _candidateservice.ViewCandidatesList();

            return View(CandidateList);

        }

        public IActionResult DownloadResumefromdb(int id)
        {
           var candidate =  _candidateservice.DownloadResume(id);

           if (candidate.Resume == null || candidate == null)
           {
               return NotFound();
           }
            var resumestream = new MemoryStream(candidate.Resume);

            return File(candidate.Resume, "application/msword", $"{candidate.CandidateName}'s Resume.doc");
           
        }

        public IActionResult DownloadImagefromdb(int id)
        {
            var candidate = _candidateservice.DownloadImage(id);

            if (candidate.Image == null || candidate == null)
            {
                return NotFound();
            }
            var imagestream = new MemoryStream(candidate.Image);

            return File(candidate.Image, "image/jpg", $"{candidate.CandidateName}'s Img.jpg");

        }

    }
    }

