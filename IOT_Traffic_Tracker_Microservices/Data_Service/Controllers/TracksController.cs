using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataProvider.Entities;
using DataProvider.Repositories;

namespace Data_Service.Controllers
{
    [ApiController]
    [Route("data-service/tracks")]
    public class TracksController : Controller
    {
        private readonly ITrackRepository _repo;
        public TracksController(ITrackRepository repo)
        {
            _repo = repo;
        }

        // GET api/todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Track>>> Get()
        {
            return new ObjectResult(await _repo.GetAllTracks());
        }
    }
}
