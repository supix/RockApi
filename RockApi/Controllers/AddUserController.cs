using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Commands;
using DomainModel.CQRS.Commands.AddUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddUserController : ControllerBase
    {
        private readonly ICommandHandler<AddUserCommand> handler;

        public AddUserController(ICommandHandler<AddUserCommand> handler)
        {
            this.handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }

        // POST: api/AddUser
        [HttpPost]
        public void Post([FromBody] AddUserCommand command)
        {
            handler.Handle(command);
        }
    }
}