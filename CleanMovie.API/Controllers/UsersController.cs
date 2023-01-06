using CleanMovie.Application.Qureies;
using CleanMovie.Domain.DBModels;
using CleanMovie.Domain.ReponseModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanMovie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;   
        }

        [HttpPost("GetUser")]
        public async Task<ResponseData<UserLoginDto>> Get(UserLoginDto request)
        {
            return await _mediator.Send(new GetUserLoginQuery(request));
        }

        [HttpGet("GetUserById")]
        public async Task<ResponseData<List<UserLoginDto>>> GetUserById(int? id)
        {
            return await _mediator.Send(new GetUserLoginByIdQuery(id));
        }
    }
}
