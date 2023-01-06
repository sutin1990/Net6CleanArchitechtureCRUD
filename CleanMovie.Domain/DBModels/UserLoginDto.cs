using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Domain.DBModels
{
    public class UserLoginDto
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int UserRolesId { get; set; }
        public UserRoles? UserRoles { get; set; }
        public List<MoviesRentalTransaction>? MoviesRentalTransactions { get; set; }
    }

    public class UserLoginDtoResponse
    {
        public string Token { get; set; } = string.Empty;
    }
}
