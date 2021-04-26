using GPIHTask.Application.Interfaces;
using GPIHTask.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GPIHTask.Application.MarketCqrs.Queries.GetMarketList
{
    public class GetMarketListQuery : IRequest<List<Market>>
    {
        public class GetMarketListQueryHandler : IRequestHandler<GetMarketListQuery, List<Market>>
        {
            private readonly IApplicationDbContext _applicationDbContext;

            public GetMarketListQueryHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<List<Market>> Handle(GetMarketListQuery request, CancellationToken cancellationToken)
            {
                return await _applicationDbContext.Markets.ToListAsync();
            }
        }
    }
}
