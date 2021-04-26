using GPIHTask.Application.Interfaces;
using GPIHTask.Domain.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GPIHTask.Application.ApplicationUserSqrs.Queries.GetApplicationUserById
{
    public class GetApplicationUserListQuery : IRequest<List<ApplicationUserDto>>
    {
        public class GetApplicationUserListQueryHandler : IRequestHandler<GetApplicationUserListQuery, List<ApplicationUserDto>>
        {
            private readonly IApplicationDbContext _applicationDbContext;

            public GetApplicationUserListQueryHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<List<ApplicationUserDto>> Handle(GetApplicationUserListQuery request, CancellationToken cancellationToken)
            {
                List<ApplicationUserDto> applicationUserDtos = new List<ApplicationUserDto>();
                var applicationUsers = await _applicationDbContext.ApplicationUsers.ToListAsync();
                foreach (var applicationUser in applicationUsers)
                {
                    var applicationUserDto = new ApplicationUserDto();
                    applicationUserDto.Id = applicationUser.Id;
                    applicationUserDto.UserName = applicationUser.UserName;
                    applicationUserDto.FullName = applicationUser.FullName;
                    applicationUserDtos.Add(applicationUserDto);
                }

                return applicationUserDtos;
            }
        }
    }
}
