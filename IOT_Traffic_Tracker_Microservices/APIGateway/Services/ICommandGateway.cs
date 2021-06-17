using CommandProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Services
{
    public interface ICommandGateway
    {
        Task<IEnumerable<Command>> GetCommands();
    }
}
