using System;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using DomainModel.CQRS.Queries.GetUsers;
using DomainModel.Classes.User;
using DomainModel.Classes;
using Microsoft.Extensions.Configuration;


namespace Persistence.SQLServer.data
{
    public class CIRDbContext: DbContext
    {
        

        public IConfiguration Configuration { get; }

        private readonly DbContextOptions<CIRDbContext> _dbContextOptions;
       
        public CIRDbContext(DbContextOptions<CIRDbContext> options,IConfiguration configuration)
            : base(options)
        {
            _dbContextOptions = options;
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {          
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SqlServer"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                    }
                 );
        }

        public DbSet<Users> Users { get; set; }
    }
}

