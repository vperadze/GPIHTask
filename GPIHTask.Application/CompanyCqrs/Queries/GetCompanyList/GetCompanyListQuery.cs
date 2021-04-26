using GPIHTask.Application.Interfaces;
using GPIHTask.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GPIHTask.Application.CompanyCqrs.Queries.GetCompanyList
{
    public class GetCompanyListQuery : IRequest<List<Company>>
    {
        public class GetCompanyListQueryHandler : IRequestHandler<GetCompanyListQuery, List<Company>>
        {
            private readonly IApplicationDbContext _applicationDbContext;

            public GetCompanyListQueryHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<List<Company>> Handle(GetCompanyListQuery request, CancellationToken cancellationToken)
            {
                return await _applicationDbContext.Companies.ToListAsync();
            }
        }
    }
}
