using Microsoft.AspNetCore.Mvc;

namespace SEP_App.Models
{
    public class CandidateService
    {
        private readonly SEPDbContext _Cancontext;
        public CandidateService(SEPDbContext Cancontext)
        {
            this._Cancontext = Cancontext;
        }


        public string CandidateInformation(CandidateDetails cd)
        {
            _Cancontext.CandidateDetails.Add(cd);
            _Cancontext.SaveChanges();
            return "registration successful";
        }

        public CandidateDetails SignIn(CandidateDetails cd)
        {
            var login = _Cancontext.CandidateDetails.FirstOrDefault(a => a.Email == cd.Email && a.Password == cd.Password);
            return login;
        }

        public void AddCandidates(AddCandidate ad, IFormFile file, IFormFile image)
        {

            {
                using (var memoryStream = new MemoryStream())
                {
                    file.CopyToAsync(memoryStream);
                    var fileData = memoryStream.ToArray();
                    ad.Resume = fileData;
                    ad.Image = fileData;
                    _Cancontext.AddCandidates.Add(ad);
                    _Cancontext.SaveChanges();
                }

            }
        }

        public List<AddCandidate> ViewCandidatesList()
        {

            return _Cancontext.AddCandidates.ToList();

        }

        public AddCandidate DownloadResume(int id)
        {
            var candidate = _Cancontext.AddCandidates.Find(id);

            return candidate;
            
        }

        public AddCandidate DownloadImage(int id)
        {
            var candidate = _Cancontext.AddCandidates.Find(id);

            return candidate;

        }

    }

}





