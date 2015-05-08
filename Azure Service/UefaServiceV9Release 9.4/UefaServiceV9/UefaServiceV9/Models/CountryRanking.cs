using System.ComponentModel.DataAnnotations;

namespace UefaServiceV9.Models
{
    public class CountryRanking
    {
        [Required]
        public int Id { get; set; } //team id

        [Required]
        [StringLength(35, MinimumLength = 3, ErrorMessage = "Country range 3-35"), RegularExpression(@"^[A-Za-z\n\r\0-9_ ]+$", ErrorMessage = "Letters, Numbers and Asterics only")]
        public string CountryName { get; set; }
     

        [DisplayFormat(DataFormatString = "{0:#,##0.000#}", ApplyFormatInEditMode = true)]
        [Required, Range(0, 999)]
        public double Ranking { get; set; }
        
    }
}