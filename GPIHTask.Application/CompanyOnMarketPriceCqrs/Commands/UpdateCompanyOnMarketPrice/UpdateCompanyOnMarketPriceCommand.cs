using GPIHTask.Application.Common.Exceptions;
using GPIHTask.Application.Interfaces;
using GPIHTask.Domain.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace GPIHTask.Application.CompanyOnMarketPriceOnMarketPriceCqrs.Commands.UpdateCompanyOnMarketPriceOnMarketPrice
{
    public class UpdateCompanyOnMarketPriceCommand : IRequest<CompanyOnMarketPriceDto>
    {
        public int Id { get; set; }
        public decimal Price { get; set; }

        public class UpdateCompanyOnMarketPriceCommandHandler : IRequestHandler<UpdateCompanyOnMarketPriceCommand, CompanyOnMarketPriceDto>
        {
            private readonly IApplicationDbContext _applicationDbContext;
            public UpdateCompanyOnMarketPriceCommandHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<CompanyOnMarketPriceDto> Handle(UpdateCompanyOnMarketPriceCommand request, CancellationToken cancellationToken)
            {
                var companyOnMarketPrice = await _applicationDbContext.CompanyOnMarketPrices.FindAsync(request.Id);
                if(companyOnMarketPrice == null)
                    throw new NotFoundException(nameof(companyOnMarketPrice), request.Id);

                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    companyOnMarketPrice.Price = request.Price;
                    _applicationDbContext.CompanyOnMarketPrices.Update(companyOnMarketPrice);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    scope.Complete();
                }

                var companyOnMarketPriceDto = new CompanyOnMarketPriceDto();
                companyOnMarketPrice.Id = companyOnMarketPrice.Id;
                companyOnMarketPrice.MarketId = companyOnMarketPrice.MarketId;
                companyOnMarketPrice.CompanyId = companyOnMarketPrice.CompanyId;
                companyOnMarketPrice.Price = companyOnMarketPrice.Price;

                return companyOnMarketPriceDto;
            }
        }
    }
}
