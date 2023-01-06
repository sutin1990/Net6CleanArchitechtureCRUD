using CleanMovie.Domain.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Domain.ReponseModels
{
    public class RequestDataConditionTransaction
    {
        public DateTime RentDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal LateFines { get; set; } = 0;
        public string UserNameStaffRent { get; set; } = string.Empty;
        public string UserNameStaffReturn { get; set; } = string.Empty;
        public string UserNameCustomer { get; set; } = string.Empty;
        public string MovieName { get; set; } = string.Empty;
    }
}
