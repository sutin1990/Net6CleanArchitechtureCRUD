using CleanMovie.Domain.DBModels;
using CleanMovie.Domain.ReponseModels;
using MediatR;

namespace CleanMovie.Application.Qureies
{
    public record GetMoviesRentalTransactionByIdQuery(int id): IRequest<ResponseData<MoviesRentalTransaction>>;
}
