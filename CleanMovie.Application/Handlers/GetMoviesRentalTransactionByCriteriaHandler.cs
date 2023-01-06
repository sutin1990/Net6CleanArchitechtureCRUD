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
    public class GetMoviesRentalTransactionByCriteriaHandler : IRequestHandler<GetMoviesRentalTransactionByCriteriaQuery, ResponseData<List<MoviesRentalTransaction>>>
    {
        private readonly IMovieRentalTransactionService _service;

        public GetMoviesRentalTransactionByCriteriaHandler(IMovieRentalTransactionService service)
        {
            _service = service;
        }

        public async Task<ResponseData<List<MoviesRentalTransaction>>> Handle(GetMoviesRentalTransactionByCriteriaQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_service.GetMoviesRentalTransactionByCriteria(request.requestDataConditionTransaction).Result);
        }
    }
}
