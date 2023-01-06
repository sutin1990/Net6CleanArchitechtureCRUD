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
    public class DeleteMovieRentalTransactionHandler : IRequestHandler<DeleteMovieRentalTransactionQuery, ResponseData<MoviesRentalTransaction>>
    {
        private readonly IMovieRentalTransactionService _service;
        public DeleteMovieRentalTransactionHandler(IMovieRentalTransactionService service)
        {
            _service = service; 
        }
        public async Task<ResponseData<MoviesRentalTransaction>> Handle(DeleteMovieRentalTransactionQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_service.DeleteMoviesRentalTransaction(request.id).Result);
        }
    }
}
