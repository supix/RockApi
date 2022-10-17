using System;
using DomainModel.Classes.User;
using DomainModel.Services.User;
using Persistence.SQLServer.data;
using Serilog;

namespace Persistence.SQLServer.Implementations.User
{
    internal class AddUser : IAddUser
    {
        private readonly CIRDbContext dbContext;

        public AddUser(CIRDbContext CIRdbContext)
        {
            this.dbContext = CIRdbContext;
        }

        public void Save(Users users)
        {
            try
            {
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(users.Password);
                users.hashPwd(passwordHash);

                dbContext.Add(users);
                dbContext.SaveChanges();
            }
            catch(Exception Ex)
            {
                Log.Debug("Errore Insert : {@classe} {@message}", this.ToString(), Ex.Message);
                throw new NotImplementedException("Errore Durante Inserimento", Ex);
            }       
        }
    }
}