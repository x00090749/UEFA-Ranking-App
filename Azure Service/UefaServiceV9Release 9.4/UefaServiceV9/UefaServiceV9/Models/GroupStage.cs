

using System.ComponentModel.DataAnnotations;

namespace UefaServiceV9.Models
{
    public class GroupStage
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Name range 3-25"), RegularExpression(@"^[A-Za-z\n\r\0-9_ ]+$", ErrorMessage = "Letters, Numbers and Asterics only")]
        public string TeamName { get; set; }

        [Required, StringLength(3, MinimumLength = 3, ErrorMessage = "Please use 3 Characters only"), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use Letters Only")]
        public string CountryCode { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0.000#}", ApplyFormatInEditMode = true)]
        [Required, Range(0, 999)]
        public double Ranking { get; set; }
        
    }
}
    
