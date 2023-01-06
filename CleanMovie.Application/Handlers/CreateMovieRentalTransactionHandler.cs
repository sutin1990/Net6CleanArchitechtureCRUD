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
    public class CreateMovieRentalTransactionHandler: IRequestHandler<CreateMovieRentalTransactionQuery, ResponseData<MoviesRentalTransaction>>
    {
        private readonly IMovieRentalTransactionService _service;

        public CreateMovieRentalTransactionHandler(IMovieRentalTransactionService service)
        {
            _service = service;
        }

        public async Task<ResponseData<MoviesRentalTransaction>> Handle(CreateMovieRentalTransactionQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_service.CreateMoviesRentalTransaction(request.moviesRentalTransaction).Result);
        }
    }
}
