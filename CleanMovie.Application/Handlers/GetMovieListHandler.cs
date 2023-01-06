using CleanMovie.Application.Qureies;
using CleanMovie.Domain.DBModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application.Handlers
{
    public class GetMovieListHandler : IRequestHandler<GetMovieListQuery, List<Movie>>
    {
        private readonly IMovieService _service;
        public GetMovieListHandler(IMovieService movieService)
        {
            _service = movieService;
        }
    
        public Task<List<Movie>> Handle(GetMovieListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_service.GetAllMovies());
        }
    }
}
