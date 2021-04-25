using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Queries;
using DomainModel.CQRS.Queries.GetUsers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUsersController : ControllerBase
    {
        private readonly IQueryHandler<GetUsersQuery, GetUsersQueryResult> handler;

        public GetUsersController(IQueryHandler<GetUsersQuery, GetUsersQueryResult> handler)
        {
            this.handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }

        // GET: api/GetUsers
        [HttpGet]
        public GetUsersQueryResult Get([FromQuery] GetUsersQuery query)
        {
            return this.handler.Handle(query);
        }
    }
}