using GPIHTask.Application.Common.Exceptions;
using GPIHTask.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GPIHTask.Application.MarketCqrs.Commands.DeleteMarket
{
    public class DeleteMarketCommand : IRequest
    {
        public int Id { get; set; }
        public class DeleteMarketCommandHandler : IRequestHandler<DeleteMarketCommand>
        {
            private readonly IApplicationDbContext _applicationDbContext;
            public DeleteMarketCommandHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<Unit> Handle(DeleteMarketCommand request, CancellationToken cancellationToken)
            {
                var Market = await _applicationDbContext.Markets.FindAsync(request.Id);
                if (Market == null)
                    throw new NotFoundException(nameof(Market), request.Id);

                _applicationDbContext.Markets.Remove(Market);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
