using CleanMovie.Application.Qureies;
using CleanMovie.Domain.DBModels;
using CleanMovie.Domain.ReponseModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanMovie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovieRentalTransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieRentalTransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("GetMoviesRentalTransactionByCriteria")]
        [HttpPost]
        public async Task<ResponseData<List<MoviesRentalTransaction>>> GetMoviesRentalTransactionByCriteria(RequestDataConditionTransaction request)
        {
            return await _mediator.Send(new GetMoviesRentalTransactionByCriteriaQuery(request));
        }

        [Route("GetMoviesRentalTransactionById/{id}")]
        [HttpGet]
        public async Task<ResponseData<MoviesRentalTransaction>> GetMoviesRentalTransactionById(int id)
        {
            return await _mediator.Send(new GetMoviesRentalTransactionByIdQuery(id));
        }

        [Route("Create")]
        [HttpPost]
        public async Task<ResponseData<MoviesRentalTransaction>> Create(MoviesRentalTransaction request)
        {
            return await _mediator.Send(new CreateMovieRentalTransactionQuery(request));
        }

        [Route("Update")]
        [HttpPut]
        public async Task<ResponseData<MoviesRentalTransaction>> Update(MoviesRentalTransaction request)
        {
            return await _mediator.Send(new UpdateMovieRentalTransactionQuery(request));
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public async Task<ResponseData<MoviesRentalTransaction>> Delete(int id)
        {
            return await _mediator.Send(new DeleteMovieRentalTransactionQuery(id));
        }

    }

}
