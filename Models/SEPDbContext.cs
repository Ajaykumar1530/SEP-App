global using Microsoft.EntityFrameworkCore;

namespace SEP_App.Models
{
    public class SEPDbContext:DbContext
    {

        public SEPDbContext(DbContextOptions<SEPDbContext> options):base(options)
        {

        }

        public virtual DbSet<CandidateDetails> CandidateDetails { get; set; }
        public virtual DbSet<OnlineTest> OnlineTests { get; set; }
        public virtual DbSet<AddCandidate> AddCandidates { get; set; }




    }
}
