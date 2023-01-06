using CleanMovie.Application.Qureies;
using CleanMovie.Domain.DBModels;
using CleanMovie.Domain.ReponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application.Handlers
{
    public class GetMoviesRentalTransactionByIdHandler : IRequestHandler<GetMoviesRentalTransactionByIdQuery, ResponseData<MoviesRentalTransaction>>
    {
        private readonly IMovieRentalTransactionService _service;

        public GetMoviesRentalTransactionByIdHandler(IMovieRentalTransactionService service)
        {
            _service = service;
        }
        public async Task<ResponseData<MoviesRentalTransaction>> Handle(GetMoviesRentalTransactionByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_service.GetMoviesRentalTransactionById(request.id).Result);
        }
    }
}
