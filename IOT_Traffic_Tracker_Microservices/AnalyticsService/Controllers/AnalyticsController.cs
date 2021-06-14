using DataProvider.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiddhiProvider.Models;
using RabbitMQProvider.Send;

namespace AnalyticsService.Controllers
{
    [ApiController]
    [Route("analytics-service")]
    public class AnalyticsController : Controller
    {
        private readonly ITrackRepository _repo;
        private readonly IAnalyticCommandSender _analyticCommandSender;

        public AnalyticsController(TrackRepository trackRepository, IAnalyticCommandSender analyticCommandSender)
        {
            _repo = trackRepository;
            _analyticCommandSender = analyticCommandSender;
        }

        [HttpPost()]
        public async Task<ActionResult> CreateAnalyticsResult([FromBody] SiddhiOutputModel siddhiOutput)
        {
            var analyticsResult = siddhiOutput.Event;

            analyticsResult.Id = await _repo.GetNextAnalyticsResultId();
            await _repo.Create(analyticsResult);

            //_analyticCommandSender.Send(null);

            return Ok("Analytics result successfully saved to database");
        }
    }
}
