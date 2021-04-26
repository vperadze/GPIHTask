using GPIHTask.Application.MarketCqrs.Commands.CreateMarket;
using GPIHTask.Application.MarketCqrs.Commands.DeleteMarket;
using GPIHTask.Application.MarketCqrs.Commands.UpdateMarket;
using GPIHTask.Application.MarketCqrs.Queries.GetMarketById;
using GPIHTask.Application.MarketCqrs.Queries.GetMarketList;
using GPIHTask.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GPIHTask.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketController : BaseController
    {
        [HttpGet]
        [Route("GetList")]
        public async Task<ActionResult<List<Market>>> GetList()
        {
            return await Mediator.Send(new GetMarketListQuery());
        }

        [HttpGet("{id}")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<Market>> GetById(int id)
        {
            return await Mediator.Send(new GetMarketByIdQuery() { Id = id });
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Market>> Create([FromBody] CreateMarketCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<Market>> Update([FromBody] UpdateMarketCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        [Route("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteMarketCommand() { Id = id });
            return Ok();
        }
    }
}
