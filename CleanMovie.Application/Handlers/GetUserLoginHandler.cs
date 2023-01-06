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
    public class GetUserLoginHandler: IRequestHandler<GetUserLoginQuery, ResponseData<UserLoginDto>>
    {
        private readonly IUserLoginDtoService _service;
        public GetUserLoginHandler(IUserLoginDtoService service)
        {
            _service = service;
        }

        public Task<ResponseData<UserLoginDto>> Handle(GetUserLoginQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_service.GetUserLogin(request.userLoginDto).Result);
        }
    }
}
