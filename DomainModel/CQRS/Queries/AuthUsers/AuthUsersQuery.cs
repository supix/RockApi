using System;
using System.Text.Json.Serialization;
using CQRS.Queries;

namespace DomainModel.CQRS.Queries.AuthUsers
{
    public class AuthUsersQuery : IQuery<AuthUsersQueryResult>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Expiration_date { get; set; }
        public string Token { get; set; }
    }
}

