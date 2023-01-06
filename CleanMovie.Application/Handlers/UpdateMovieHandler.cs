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
    public class UpdateMovieHandler: IRequestHandler<UpdateMovieQuery, ResponseData<Movie>>
    {
        private readonly IMovieService _service;
        public UpdateMovieHandler(IMovieService service)
        {
            _service = service; 
        }

        public Task<ResponseData<Movie>> Handle(UpdateMovieQuery request, CancellationToken cancellationToken)
        {
            return  Task.FromResult(_service.EditMovies(request.movie).Result);
        }
    }
}
