using System;
using Persistence.SQLServer.data;
using DomainModel.Classes.User;
using DomainModel.Services.User;
using Microsoft.EntityFrameworkCore;
using DomainModel.CQRS.Queries.GetUsers;
using Serilog;

namespace Persistence.SQLServer.Implementations.User
{
    internal class UpdateUser: IUpdateUser
    {
        private readonly CIRDbContext dbContext;

        public UpdateUser(CIRDbContext CIRdbContext)
        {
            this.dbContext = CIRdbContext;
        }

        public void Update(Users userToBeSaved)
        {
            try
            {
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(userToBeSaved.Password);
                var userInDB = dbContext.Users.Find(userToBeSaved.Username);  

                if (userInDB != null)
                {
                    userInDB.Password = passwordHash; //.hashPwd(passwordHash)
                    userInDB.FirstName = userToBeSaved.FirstName;
                    userInDB.LastName = userToBeSaved.LastName;
                    userInDB.Active = userToBeSaved.Active;
                    //dbContext.Entry(userToBeSaved).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception Ex)
            {
                Log.Debug("Errore Insert : {@classe} {@message}", this.ToString(), Ex.Message);
                throw new NotImplementedException("Errore Durante Aggiornamento", Ex);
            }
        }

    }
}

