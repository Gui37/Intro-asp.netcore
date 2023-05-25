using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPIntro.Models
{
    public class Filme
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string? Title { get; set; }

        [Display(Name =" Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string? Genre { get; set; }
      
        
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal (18, 2")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(5)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        public string? Rating { get; set; }
    }
}
