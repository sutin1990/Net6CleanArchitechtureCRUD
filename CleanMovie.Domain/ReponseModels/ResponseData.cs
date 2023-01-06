using CleanMovie.Domain.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Domain.ReponseModels
{
    public partial class ResponseData<T>
    {
        public string ResponseMessage { get; set; } = string.Empty;
        public string RequestCode { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}
