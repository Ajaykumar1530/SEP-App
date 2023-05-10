using System.ComponentModel.DataAnnotations;

namespace SEP_App.Models
{
    public class CandidateDetails
    {
        [Key]
        public int CandidateId { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string? CandidateName { get; set; }
        [Range(0, 100)]
        public int Age { get; set; }
        [RegularExpression(@"^(\+?\d{1,3}[- ]?)?\d{10}$", ErrorMessage = "Invalid mobile number")]
        public string MobileNo { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Date)]
        public DateTime Passoutyear { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string? HighestQualification { get; set; }

        public int? score { get; set; }
        [DataType(DataType.Date)]
        public string? date { get; set; }
    }
}
