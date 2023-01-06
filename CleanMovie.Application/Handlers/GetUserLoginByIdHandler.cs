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
    public class GetUserLoginByIdHandler : IRequestHandler<GetUserLoginByIdQuery, ResponseData<List<UserLoginDto>>>
    {
        private readonly IUserLoginDtoService _service;
        public GetUserLoginByIdHandler(IUserLoginDtoService service)
        {
            _service = service;
        }
        public async Task<ResponseData<List<UserLoginDto>>> Handle(GetUserLoginByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_service.GetUserLoginById(request.id).Result);
        }
    }
}
