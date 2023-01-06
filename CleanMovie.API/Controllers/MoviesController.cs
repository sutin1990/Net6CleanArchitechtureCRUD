using CleanMovie.Application;
using CleanMovie.Application.Qureies;
using CleanMovie.Domain.DBModels;
using CleanMovie.Domain.ReponseModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanMovie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MoviesController : ControllerBase
    {
        // GET: api/<MoviesController>
        private readonly IMediator _mediator;
        private readonly IMovieService _movieService;
        private readonly IConfiguration _configurationManager;
        public MoviesController(IMediator mediator, IMovieService movieService, IConfiguration configurationManager)
        {
            _mediator = mediator;
            _movieService = movieService;
            _configurationManager = configurationManager;
        }

        [HttpGet("GetAllMovie")]
        public async Task<List<Movie>> Get()
        {
            return await _mediator.Send(new GetMovieListQuery());
        }

        [HttpGet("GetMovie/{id}")]
        public async Task<ResponseData<Movie>> Get(int id)
        {
            return await _mediator.Send(new GetMovieByIdQuery(id));
        }

        [HttpPost("CreateMovie")]
        public ActionResult<Movie> PostMovie(Movie movie)
        {
            var res = _movieService.CreateMovie(movie);
            return Ok(res);
        }

        [HttpPut("UpdateMovie")]
        public async Task<ResponseData<Movie>> PutMovie(Movie movie)
        {
            var res = await _mediator.Send(new UpdateMovieQuery(movie));
            return res;
        }

        [HttpDelete("DeleteMovie/{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(int id)
        {
            await _mediator.Send(new DeleteMovieQuery(id));

            return Ok(await GetDbMovie());
        }        

        private async Task<List<Movie>> GetDbMovie()
        {
            var result = await _mediator.Send(new GetMovieListQuery());
            return result.ToList();
        }

    }
}
