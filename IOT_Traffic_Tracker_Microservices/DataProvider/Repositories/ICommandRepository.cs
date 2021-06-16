using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CommandProvider.Models;
using DataProvider.Entities;

namespace DataProvider.Repositories
{
    public interface ICommandRepository
    {
        Task<IEnumerable<Command>> GetAllCommands();
        Task<Command> GetCommand(long id);
        Task Create(Command command);
        Task<long> GetNextId();
    }
}
