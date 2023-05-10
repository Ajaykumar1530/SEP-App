using System.ComponentModel.DataAnnotations;

namespace SEP_App.Models
{
    public class AddCandidate
    {
        [Key]
        public int id { get; set; } 
        [Required]
        public string CandidateName { get; set; }
        public string Referredby { get; set; }
        [Required]
        public string Address { get; set; }
        public string PreviousExperience { get; set; }
        [Required]
        public string HighestQualification { get; set; }
        [Required]
    
        [DataType(DataType.Date)]
        public DateTime Passoutyear { get; set; }
        [Required]
        public string Technology { get; set; }
        [Required]
        public int CareerGap  { get; set; }
        [Required]
        public long Contact  { get; set; }
        [Required]
        [EmailAddress]
        public int Email { get; set; }
        public byte[]? Resume { get; set; }
        public byte[]? Image { get; set; }

    }
}
