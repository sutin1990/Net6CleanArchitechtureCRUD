using CleanMovie.Domain.DBModels;
using CleanMovie.Domain.ReponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application.Qureies
{
    public record GetMovieByIdQuery(int id) : IRequest<ResponseData<Movie>>;
}
