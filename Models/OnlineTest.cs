using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEP_App.Models
{
    public partial class OnlineTest
    {
        [Key]
        public int Qno { get; set; }
        public string Question { get; set; } = null!;
        public string? OptionA { get; set; }
        public string? OptionB { get; set; }
        public string? OptionC { get; set; }
        public string? OptionD { get; set; }
        public int? answer { get; set; }
    }
}
