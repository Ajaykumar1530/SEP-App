using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace SEP_App.Models
{
    public class InterviewOnlineTestService
    {
        private readonly SEPDbContext _sepdb;
     
        public InterviewOnlineTestService(SEPDbContext sepdb)
        {
            this._sepdb = sepdb;
          
        }

        public List<OnlineTest> GetAllQuestions()
        {
            return _sepdb.OnlineTests.ToList(); 
        }

        public void Scoresubmission(ITempDataDictionary tempdata)
        {
            var myscore = tempdata["score"];
            var id = tempdata["id"];  
            
            if (id != null)
            {
              var Id =  _sepdb.CandidateDetails.Find(id);
                Id.score =(int)myscore;
                DateTime date = DateTime.Today;
                string indianDate = date.ToString("dd/MM/yyyy");
                Id.date = indianDate;
                if(Id != null)  
                {
                    _sepdb.CandidateDetails.Update(Id);
                    _sepdb.SaveChanges();
                }    
            }

        }

        public List<CandidateDetails> GetTestScore()
        {
            var scores = _sepdb.CandidateDetails.ToList();
            return scores;
        }
       
    }
}
