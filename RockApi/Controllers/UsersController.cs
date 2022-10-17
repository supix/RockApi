using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CQRS.Commands;
using DomainModel.Classes;
using DomainModel.CQRS.Commands.User.AddUser;
using DomainModel.CQRS.Commands.User.DeleteUser;
using DomainModel.CQRS.Commands.User.UpdateUser;
using DomainModel.CQRS.Queries.AuthUsers;
using DomainModel.CQRS.Queries.GetUsers;
using DomainModel.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace RockApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        // Commmand
        private readonly IAddUser userAdd;
        private readonly IDeleteUser deleteUser;
        private readonly IUpdateUser updateUser;
        // Command Handler 
        private readonly ICommandHandler<AddUserCommand> handlerAdd;
        private readonly ICommandHandler<DeleteUserCommand> handlerDelete;
        private readonly ICommandHandler<UpdateUserCommand> handlerUpdate;    
        // Query
        private readonly IGetUsers getUsers;
        private readonly IAuthenticateUser authenticateUser;

        public UsersController(
            //IAuthenticateUser authenticateUser,
            ICommandHandler<AddUserCommand> handlerAdd,
            ICommandHandler<DeleteUserCommand> handlerDelete,
            ICommandHandler<UpdateUserCommand> handlerUpdate,
            IAddUser userAdd,
            IDeleteUser deleteUser,
            IUpdateUser updateUser,
            IGetUsers getUsers,
            IAuthenticateUser authenticateUser)
        {
            
            this.handlerAdd = handlerAdd ?? throw new ArgumentNullException(nameof(handlerAdd));
            this.handlerDelete = handlerDelete ?? throw new ArgumentNullException(nameof(handlerDelete));
            this.handlerUpdate = handlerUpdate ?? throw new ArgumentNullException(nameof(handlerUpdate));

            this.userAdd = userAdd ?? throw new ArgumentNullException(nameof(userAdd));
            this.deleteUser = deleteUser ?? throw new ArgumentNullException(nameof(deleteUser));
            this.updateUser = updateUser ?? throw new ArgumentNullException(nameof(updateUser));

            this.getUsers = getUsers ?? throw new ArgumentNullException(nameof(getUsers));
            this.authenticateUser = authenticateUser ?? throw new ArgumentNullException(nameof(authenticateUser));
        }  

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ActionResult<IEnumerable<AuthUsersQuery>> Auth([FromBody] AuthUsersQuery authUsersQuery)
        {
            return Ok(authenticateUser.Authenticate(authUsersQuery.Username, authUsersQuery.Password));
        }

        // POST: api/user
        [HttpPost]
        public void Post([FromBody] AddUserCommand command)
        {
             handlerAdd.Handle(command);
        }
        
        // PUT: api/user
        [HttpPut]
        public void Put([FromBody] UpdateUserCommand updateUserCommand)
        {
             handlerUpdate.Handle(updateUserCommand);
        }

        // PUT: api/user
        [HttpDelete]
        public void Delete([FromBody] DeleteUserCommand deleteUserCommand)
        {
            handlerDelete.Handle(deleteUserCommand);
        }

        // GET: api/users
        [HttpGet]
        public ActionResult<IEnumerable<GetUsersQuery>> Get()
        {
            return Ok(getUsers.Get());
        }

        // GET: api/user/username
        [HttpGet("{username}")]
        [Route("api/users/username")]
        public ActionResult<IEnumerable<AddUserCommand>> Get(string username)
        {
            return Ok(getUsers.getbyUsername(username));
        }
    }
}