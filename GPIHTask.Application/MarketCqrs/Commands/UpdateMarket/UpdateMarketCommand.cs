using GPIHTask.Application.Common.Exceptions;
using GPIHTask.Application.Interfaces;
using GPIHTask.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace GPIHTask.Application.MarketCqrs.Commands.UpdateMarket
{
    public class UpdateMarketCommand : IRequest<Market>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public class UpdateMarketCommandHandler : IRequestHandler<UpdateMarketCommand, Market>
        {
            private readonly IApplicationDbContext _applicationDbContext;
            public UpdateMarketCommandHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<Market> Handle(UpdateMarketCommand request, CancellationToken cancellationToken)
            {
                var Market = await _applicationDbContext.Markets.FindAsync(request.Id);
                if (Market == null)
                    throw new NotFoundException(nameof(Market), request.Id);

                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    Market.Title = request.Title;
                    Market.Description = request.Description;

                    _applicationDbContext.Markets.Update(Market);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    scope.Complete();
                }
                return Market;
            }
        }
    }
}
