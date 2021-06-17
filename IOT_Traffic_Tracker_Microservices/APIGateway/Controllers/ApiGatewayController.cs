using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataProvider.Entities;
using APIGateway.Services;
using System.Net.Http;

namespace APIGateway.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiGatewayController : Controller
    {
        private readonly IDataGateway _dataService;
        private readonly ICommandGateway _commandService;

        public ApiGatewayController(IDataGateway dataService, ICommandGateway commandService)
        {
            _dataService = dataService;
            _commandService = commandService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var result =  await _dataService.GetAllTracks();
            return Ok(result);
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Track>> Get(int id)
        //{
        //    var track = await _dataService.GetTrack(id);
        //    if (track == null)
        //        return new NotFoundResult();

        //    return new ObjectResult(track);
        //}

        [HttpPut("tracks/{id}")]
        public async Task<ActionResult<Track>> Put(int id, [FromBody] Track track)
        {
            var result = await _dataService.UpdateTrack(id, track);
            if (result == null)
                return new NotFoundResult();
            return new OkObjectResult(track);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _dataService.DeleteTrack(id);
            return new OkResult();
        }

        [HttpGet("max-speed/{maxSpeed}")]
        public async Task<ActionResult> GetTracks(int maxSpeed)
        {
            var result = await _dataService.GetTracks(maxSpeed);
            if (result == null)
                return new NotFoundResult();
            return Ok(result);
        }

        [HttpGet("air-distance/{airDistance}")]
        public async Task<ActionResult> GetTracksAirDistanceCondition(int airDistance)
        {
            var result = await _dataService.GetTracksAirDistanceCondition(airDistance);
            if (result == null)
                return new NotFoundResult();
            return Ok(result);
        }

        [HttpGet("commands")]
        public async Task<IActionResult> GetCommands()
        {
            var result = await _commandService.GetCommands();
            return Ok(result);
        }
    }
}
