using GPIHTask.Application.Common.Exceptions;
using GPIHTask.Application.Interfaces;
using GPIHTask.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GPIHTask.Application.MarketCqrs.Queries.GetMarketById
{
    public class GetMarketByIdQuery : IRequest<Market>
    {
        public int Id { get; set; }

        public class GetMarketByIdQueryHandler : IRequestHandler<GetMarketByIdQuery, Market>
        {
            private readonly IApplicationDbContext _applicationDbContext;

            public GetMarketByIdQueryHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<Market> Handle(GetMarketByIdQuery request, CancellationToken cancellationToken)
            {
                var market = await _applicationDbContext.Markets.FindAsync(request.Id);
                if (market == null)
                    throw new NotFoundException(nameof(Market), request.Id);

                return market;
            }
        }
    }
}
