using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Domain.DBModels
{
    public class MoviesRentalTransaction
    {
        [Key]
        public int Id  { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        public DateTime RentDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        public DateTime ExpiryDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        public DateTime ReturnDate { get; set; }
        public decimal LateFines { get; set; } = 0;        
        public int MovieId { get; set; }
        public int CutomerId { get; set; }
        public int StaffRentId { get; set; }
        public int StaffReturnId { get; set; }
        
        public virtual UserLoginDto? UserLoginDto { get; set; }
        public virtual Movie? Movie { get; set; }

        [NotMapped]
        public UserLoginDto? UserLoginDtoStaffRent { get; set; }
        [NotMapped]
        public UserLoginDto? UserLoginDtoStaffReturn { get; set; }
        [NotMapped]
        public UserLoginDto? UserLoginDtoCustomer { get; set; }        
        
    }
}
