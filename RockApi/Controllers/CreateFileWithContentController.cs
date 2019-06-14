using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Commands;
using DomainModel.CQRS.Commands.CreateFileWithContent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateFileWithContentController : ControllerBase
    {
        private readonly ICommandHandler<CreateFileWithContentCommand> handler;

        public CreateFileWithContentController(ICommandHandler<CreateFileWithContentCommand> handler)
        {
            this.handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }

        // POST: api/CreateFileWithContent
        [HttpPost]
        public void Post([FromBody] CreateFileWithContentCommand command)
        {
            this.handler.Handle(command);
        }
    }
}
