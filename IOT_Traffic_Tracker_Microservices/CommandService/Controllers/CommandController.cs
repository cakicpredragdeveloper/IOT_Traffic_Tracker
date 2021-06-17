using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataProvider.Repositories;

namespace CommandService.Controllers
{
    [ApiController]
    [Route("commnand")]
    public class CommandController : Controller
    {
        private readonly ICommandRepository _commandRepository;

        public CommandController(ICommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCommands()
        {
            var result = await _commandRepository.GetAllCommands();
            return Ok(result);
        }
    }
}
