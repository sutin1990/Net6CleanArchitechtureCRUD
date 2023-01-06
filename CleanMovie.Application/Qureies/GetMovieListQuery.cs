using CleanMovie.Domain.DBModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application.Qureies
{
    public record GetMovieListQuery(): IRequest<List<Movie>>;
}
