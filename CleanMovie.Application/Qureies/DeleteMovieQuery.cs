using CleanMovie.Domain.DBModels;
using CleanMovie.Domain.ReponseModels;
using MediatR;

namespace CleanMovie.Application.Qureies
{
    public record DeleteMovieQuery(int id): IRequest<ResponseData<Movie>>;
}
