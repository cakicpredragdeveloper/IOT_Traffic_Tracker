using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataProvider.Entities;
using APIGateway.Services;

namespace APIGateway.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiGatewayController : Controller
    {
        private readonly IDataGateway _service;

        public ApiGatewayController(IDataGateway service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Track>>> Get()
        {
            var result = await _service.GetAllTracks();
            return Ok(result);
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Track>> Get(int id)
        //{
        //    var track = await _service.GetTrack(id);
        //    if (track == null)
        //        return new NotFoundResult();

        //    return new ObjectResult(track);
        //}

        [HttpPut("{id}")]
        public async Task<ActionResult<Track>> Put(int id, [FromBody] Track track)
        {
            var result = await _service.UpdateTrack(id, track);
            if (result == null)
                return new NotFoundResult();
            return new OkObjectResult(track);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteTrack(id);
            return new OkResult();
        }

        [HttpGet("max-speed/{maxSpeed}")]
        public async Task<ActionResult> GetTracks(int maxSpeed)
        {
            var result = await _service.GetTracks(maxSpeed);
            if (result == null)
                return new NotFoundResult();
            return Ok(result);
        }

        [HttpGet("air-distance/{airDistance}")]
        public async Task<ActionResult> GetTracksAirDistanceCondition(int airDistance)
        {
            var result = await _service.GetTracksAirDistanceCondition(airDistance);
            if (result == null)
                return new NotFoundResult();
            return Ok(result);
        }

    }
}
