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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Track>>> Get()
        {
            return new ObjectResult(await _repo.GetAllTracks());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Track>> Get(long id)
        {
            var track = await _repo.GetTrack(id);
            if (track == null)
                return new NotFoundResult();

            return new ObjectResult(track);
        }

        [HttpPost]
        public async Task<ActionResult<Track>> Post([FromBody] Track track)
        {
            track.Id = await _repo.GetNextId();
            await _repo.Create(track);
            return new OkObjectResult(track);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Track>> Put(long id, [FromBody] Track track)
        {
            var trackFromDb = await _repo.GetTrack(id);
            if (trackFromDb == null)
                return new NotFoundResult();
            track.Id = trackFromDb.Id;
            track.InternalId = trackFromDb.InternalId;
            await _repo.Update(track);
            return new OkObjectResult(track);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var post = await _repo.GetTrack(id);
            if (post == null)
                return new NotFoundResult();
            await _repo.Delete(id);
            return new OkResult();
        }

        [HttpPost("array-of-tracks")]
        public async Task<ActionResult> Post([FromBody] SetOfTracks setOfTracks)
        {
            foreach(var track in setOfTracks.Tracks)
            {
                track.Id = await _repo.GetNextId();
                await _repo.Create(track);
            }
            return  Ok("Tracks saved successfully!");
        }
    }
}
