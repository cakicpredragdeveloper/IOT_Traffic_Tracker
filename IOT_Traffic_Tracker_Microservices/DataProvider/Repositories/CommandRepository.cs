using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataProvider.Entities;
using DataProvider.Config;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Linq;
using CommandProvider.Models;

namespace DataProvider.Repositories
{
    public class CommandRepository: ICommandRepository
    {
        private readonly IMongoCollection<Command> _commands;
        public CommandRepository(IMongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _commands = database.GetCollection<Command>(settings.CommandsCollectionName);
        }

        public async Task<IEnumerable<Command>> GetAllCommands()
        {
            return await _commands
                          .Find(_ => true)
                          .ToListAsync();
        }

        
        public Task<Command> GetCommand(long id)
        {
            FilterDefinition<Command> filter = Builders<Command>.Filter.Eq(m => m.Id, id);

            return _commands
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task Create(Command command)
        {
            await _commands.InsertOneAsync(command);
        }


        public async Task<long> GetNextId()
        {
            return await _commands.CountDocumentsAsync(new BsonDocument()) + 1;
        }
    }
}
