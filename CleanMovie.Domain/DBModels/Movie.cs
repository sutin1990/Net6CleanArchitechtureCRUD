using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanMovie.Domain.DBModels
{
    public class Movie
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "please enter movie name!")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "please enter cost!")]
        public decimal Cost { get; set; }

        [NotMapped]
        public bool IsDeleted { get; set; }
        public List<MoviesRentalTransaction>? MoviesRentalTransactions { get; set; }

    }
}