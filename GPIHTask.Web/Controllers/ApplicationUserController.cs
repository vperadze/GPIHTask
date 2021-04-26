using GPIHTask.Application.ApplicationUserSqrs.Commands.CreateApplicationUser;
using GPIHTask.Application.ApplicationUserSqrs.Commands.DeleteApplicationUser;
using GPIHTask.Application.ApplicationUserSqrs.Commands.LoginApplicationUser;
using GPIHTask.Application.ApplicationUserSqrs.Commands.UpdateApplicationUser;
using GPIHTask.Application.ApplicationUserSqrs.Queries.GetApplicationUserById;
using GPIHTask.Application.ApplicationUserSqrs.Queries.GetApplicationUserList;
using GPIHTask.Domain.Dtos;
using GPIHTask.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GPIHTask.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : BaseController
    {
        [HttpGet]
        [Route("GetList")]
        public async Task<ActionResult<List<ApplicationUserDto>>> GetList()
        {
            return await Mediator.Send(new GetApplicationUserListQuery());
        }

        [HttpGet("{id}")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<ApplicationUserDto>> GetById(int id)
        {
            return await Mediator.Send(new GetApplicationUserByIdQuery() { Id = id });
        }

        [HttpGet]
        [Route("Login")]
        public async Task<ActionResult> Login([FromBody] LoginApplicationUserCommand command)
        {
            var token = await Mediator.Send(command);
            return Ok(new { token });
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<ApplicationUser>> Create([FromBody] CreateApplicationUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<ApplicationUser>> Update([FromBody] UpdateApplicationUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        [Route("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteApplicationUserCommand() { Id = id });
            return Ok();
        }
    }
}
