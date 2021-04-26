using GPIHTask.Application.Interfaces;
using GPIHTask.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace GPIHTask.Application.MarketCqrs.Commands.CreateMarket
{
    public class CreateMarketCommand : IRequest<Market>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public class CreateMarketCommandHandler : IRequestHandler<CreateMarketCommand, Market>
        {
            private readonly IApplicationDbContext _applicationDbContext;
            public CreateMarketCommandHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<Market> Handle(CreateMarketCommand request, CancellationToken cancellationToken)
            {
                Market Market = null;
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    Market = new Market();
                    Market.Title = request.Title;
                    Market.Description = request.Description;

                    _applicationDbContext.Markets.Add(Market);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    scope.Complete();
                }
                return Market;
            }
        }
    }
}
