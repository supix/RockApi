using System;
using System.Text.Json.Serialization;
using CQRS.Queries;

namespace DomainModel.CQRS.Queries.GetUsers
{
    public class GetUsersQuery: IQuery<GetUsersQueryResult>
    {
        public GetUsersQuery(string username,
                             string password,
                             int id,
                             string firstName,
                             string lastName,
                             bool active)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Username = username;
            this.Password = password;
            this.Active = active;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
    }
}

