using CleanMovie.Domain.DBModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Domain.PartialModels
{
    public class DataGridTransactions: MoviesRentalTransaction
    {
        [NotMapped]
        public string MovieName
        {
            get
            {
                return Movie?.Name ?? string.Empty;
            }
        }
        [NotMapped]
        public decimal MovieCost
        {
            get
            {
                return Movie?.Cost ?? 0;
            }
        }
        [NotMapped]
        public string CustomerFirstName
        {
            get
            {
                return UserLoginDtoCustomer?.FirstName ?? string.Empty;
            }
        }
        [NotMapped]
        public string StaffRentFirstName
        {
            get
            {
                return UserLoginDtoStaffRent?.FirstName ?? string.Empty;
            }
        }
        [NotMapped]
        public string StaffReturnFirstName
        {
            get
            {
                return UserLoginDtoStaffReturn?.FirstName ?? string.Empty;
            }
        }


    }
}
