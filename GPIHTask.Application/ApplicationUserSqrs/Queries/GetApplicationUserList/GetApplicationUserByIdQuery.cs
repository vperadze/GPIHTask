using GPIHTask.Application.Common.Exceptions;
using GPIHTask.Application.Interfaces;
using GPIHTask.Domain.Dtos;
using GPIHTask.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GPIHTask.Application.ApplicationUserSqrs.Queries.GetApplicationUserList
{
    public class GetApplicationUserByIdQuery : IRequest<ApplicationUserDto>
    {
        public int Id { get; set; }

        public class GetApplicationUserByIdQueryHandler : IRequestHandler<GetApplicationUserByIdQuery, ApplicationUserDto>
        {
            private readonly IApplicationDbContext _applicationDbContext;

            public GetApplicationUserByIdQueryHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<ApplicationUserDto> Handle(GetApplicationUserByIdQuery request, CancellationToken cancellationToken)
            {
                ApplicationUserDto applicationUserDto = null;
                var applicationUser = await _applicationDbContext.ApplicationUsers.FindAsync(request.Id);
                if (applicationUser == null)
                    throw new NotFoundException(nameof(ApplicationUser), request.Id);

                applicationUserDto.Id = applicationUser.Id;
                applicationUserDto.FullName = applicationUser.FullName;
                applicationUserDto.UserName = applicationUser.UserName;

                return applicationUserDto;
            }
        }
    }
}
