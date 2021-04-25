using DomainModel.Classes;
using DomainModel.Services;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CompositionRoot")]

namespace Persistence_MongoDB
{
    public class Database : IAddUser, IGetUsers
    {
        private IMongoCollection<User> usersCollection = null;

        public Database()
        {
            if (this.usersCollection == null)
                this.initializeDbConnection();
        }

        public void Add(User user)
        {
            this.usersCollection.InsertOne(user);
        }

        public IEnumerable<string> Get()
        {
            return this.usersCollection.Find(_ => true)
                .ToEnumerable()
                .Select(u => u.Username);
        }

        internal void initializeDbConnection()
        {
            BsonClassMap.RegisterClassMap<User>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(c => c.Username);
            });

            var client = new MongoClient();
            var database = client.GetDatabase("rockAPI");
            this.usersCollection = database.GetCollection<User>("users");
        }
    }
}